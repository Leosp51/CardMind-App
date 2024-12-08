using CardMind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Services.LocalServices
{
    public class ConquistasLocalService
    {
        List<Conquista> Conquistas {  get; set; }
        List<Conquista> SearchConquista { get; set; }
        public ConquistasLocalService() {
            Conquistas = new List<Conquista>();
            SearchConquista = new List<Conquista>();

        }
    }
}
