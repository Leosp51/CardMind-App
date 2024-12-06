using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Models
{
    public class Carta
    {
        public string NomeCarta { get; set; }
        public int CodCarta { get; set; }
        public int CodBaralho { get; set; }
        public string Tipo {  get; set; }
    }
}
