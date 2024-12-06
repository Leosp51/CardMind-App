using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CardMind.Models
{
    public class Conquista
    {
        public int CodConquista { get; set; }
        public string NomeConquista { get; set; }
        public string Objetivo { get; set; }
        public int Recompensa { get; set; }
        public bool IsFinish { get; set; }
        public string Cor {  get; set; }
        public string CorText { get; set; }

        public Conquista(int codConquista, string nomeConquista, string objetivo, int recompensa)
        {
            CodConquista = codConquista;
            NomeConquista = nomeConquista;
            Objetivo = objetivo;
            Recompensa = recompensa;
        }
        public Conquista() { }

        
    }
}
