using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Models
{
    public class Usuario
    {
        public int IdUser { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Dinheiro { get; set; }
        public Usuario(int idUser, string nomeUsuario, string email, string senha, int dinheiro)
        {
            IdUser = idUser;
            NomeUsuario = nomeUsuario;
            Email = email;
            Senha = senha;
            Dinheiro = dinheiro;
        }

        public Usuario()
        {
        }
    }
}
