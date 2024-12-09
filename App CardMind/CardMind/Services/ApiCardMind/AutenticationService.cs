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

        public static Usuario Usuario { get => usuario; set => usuario = value; }

        public AutenticationService() {
            //Trocar por autenticação com API
            Usuario = new Usuario();
            string status = Preferences.Default.Get("statusUsuario","primeiraVez");
            if (status == "cadastrado")
            {
                PopularUsuario();
            }
        }
        public void InserirUsuario(string nome, string email, string senha)
        {
            Usuario.NomeUsuario = nome;
            Usuario.Email = email;
            Usuario.Senha = senha;
            //inserir usuario por meio da api
            Preferences.Default.Set("nomeUsuario", nome);
            Preferences.Default.Set("emailUsuario", email);
            Preferences.Default.Set("senhaUsuario", senha);
            Preferences.Set("statusUsuario","cadastrado");
        }
        public bool Validacao(string email, string senha)
        {
            PopularUsuario();
            if (email == Usuario.Email && senha == Usuario.Senha)
                return true;
            else
                return false;
        }

        public void PopularUsuario()
        {

            Usuario.NomeUsuario = Preferences.Get("nomeUsuario", "guest");
            Usuario.Email = Preferences.Get("emailUsuario", "default");
            Usuario.Senha = Preferences.Get("senhaUsuario", "123");

        }
    }
}
