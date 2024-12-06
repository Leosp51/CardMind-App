using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Models
{
    public class CartaTexto:Carta
    {
        public string Texto {  get; set; }

        public CartaTexto()
        {
            base.Tipo = "Texto";
        }
    }
}
