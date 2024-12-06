using CardMind.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace CardMind.Services.ApiCardMind
{
    public class UsuarioService
    {
        private HttpClient client;
        private JsonSerializerOptions options;

        public UsuarioService() {
            client = new HttpClient();
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task PostUser(Usuario usuario)
        {
            Uri uri = new Uri("http://localhost:8080/usuarios");
            try
            {
                string json = JsonSerializer.Serialize<Usuario>(usuario, options);
                StringContent content = new StringContent(json);
                await client.PostAsync(uri,content);
                
                //Colocar validação da resposta
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task<bool> Autenticar(string senha, string email)
        {
            Conta conta = new Conta();
            conta.Email = email;
            conta.Senha = senha;
            Uri uri = new Uri("http://localhost:8080/usuarios");
            bool autenticado = false;
            try
            {
                string json = JsonSerializer.Serialize<Conta>(conta, options);
                StringContent content = new StringContent(json);
                var resposta = await client.PostAsync(uri, content);
                autenticado = resposta.IsSuccessStatusCode?true:false;
                //Colocar validação da resposta
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return autenticado;
        }
    }
}
