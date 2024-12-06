using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Models
{
    public class CartaPergunta:Carta
    {
        public string Pergunta { get; set; }
        public string Resposta { get; set; }

        public CartaPergunta()
        {
            base.Tipo = "Pergunta";
        }
    }
}
