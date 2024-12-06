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
        private Usuario usuario = new Usuario();
        public AutenticationService() {
            //Trocar por autenticação com API
            string status = Preferences.Get("statusUsuario","primeiraVez");
            if (status == "cadastrado")
            {
                usuario.NomeUsuario = Preferences.Get("nomeUsuario","guest");
                usuario.Email = Preferences.Get("emailUsuario", "default");
                usuario.Senha = Preferences.Get("senhaUsuario", "123");
            }
        }
        public void InserirUsuario(string nome, string email, string senha)
        {
            //inserir usuario por meio da api
            Preferences.Set("nomeUsuario", nome);
            Preferences.Set("emailUsuario", email);
            Preferences.Set("senhaUsuario", senha);
            Preferences.Set("statusUsuario","cadastrado");
        }
        public bool Validacao(string email, string senha)
        {
            return email.Equals(usuario.Email) && senha.Equals(usuario.Senha);
        }
    }
}
