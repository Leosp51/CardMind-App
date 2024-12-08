using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Models
{
    public class Baralho
    {
        public string NomeBaralho { get; set; }
        public int CodBaralho { get; set; }
        public int CodEstilo { get; set; }
        public List<Carta> Cartas { get; set; }

        //Construtor para teste abaixo
        public Baralho(string nome, int codigo)
        {
            NomeBaralho = nome;
            CodBaralho = codigo;
        }
        public Baralho() {
            NomeBaralho = string.Empty;
            Cartas = new List<Carta>();
        }
    }
}
