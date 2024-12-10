using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Models
{
    public class EstiloBaralho
    {
        public int CodEstilo { get; set; }
        public string NomeEstilo { get; set; }
        public int Valor { get; set; }
        public string Img {  get; set; }
        public string BackgroundImg { get; set; }
        public string TextColor { get; set; }
        public string BorderColor { get; set; }
        public string Color { get; set; }


        public EstiloBaralho(int codEstilo, string nomeEstilo, int valor)
        {
            CodEstilo = codEstilo;
            NomeEstilo = nomeEstilo;
            Valor = valor;
        }
        public EstiloBaralho() { }
        
    }
}
