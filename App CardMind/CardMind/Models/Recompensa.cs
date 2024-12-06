using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Models
{
    public class Recompensa
    {
        public int CodMissao { get; set; }
        public string NomeMissao { get; set; }
        // prazo (necessário um tipo Data)
        public Recompensa(int codMissao, string nomeMissao)
        {
            CodMissao = codMissao;
            NomeMissao = nomeMissao;
        }
    }
}
