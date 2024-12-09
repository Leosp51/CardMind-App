using CardMind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Services.ApiCardMind
{
    public class AutenticationService
    {
        private static Usuario usuario;
        public AutenticationService() {
            //Trocar por autenticação com API
            usuario = new Usuario();
            string status = Preferences.Default.Get("statusUsuario","primeiraVez");
            if (status == "cadastrado")
            {
                PopularUsuario();
            }
        }
        public void InserirUsuario(string nome, string email, string senha)
        {
            usuario.NomeUsuario = nome;
            usuario.Email = email;
            usuario.Senha = senha;
            //inserir usuario por meio da api
            Preferences.Default.Set("nomeUsuario", nome);
            Preferences.Default.Set("emailUsuario", email);
            Preferences.Default.Set("senhaUsuario", senha);
            Preferences.Default.Set("statusUsuario","cadastrado");
        }
        public bool Validacao(string email, string senha)
        {
            return email.Equals(usuario.Email) && senha.Equals(usuario.Senha);
        }

        public void PopularUsuario()
        {

            usuario.NomeUsuario = Preferences.Get("nomeUsuario", "guest");
            usuario.Email = Preferences.Get("emailUsuario", "default");
            usuario.Senha = Preferences.Get("senhaUsuario", "123");

        }
    }
}
