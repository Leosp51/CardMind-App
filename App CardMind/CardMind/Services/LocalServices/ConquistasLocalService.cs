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
        List<Conquista> Conquistas { get; set; }
        List<Conquista> SearchConquista { get; set; }
        public ConquistasLocalService() {
            Conquistas = new List<Conquista>();
            SearchConquista = new List<Conquista>();

            Conquistas.Add(new Conquista
            {
                CodConquista = 1,
                NomeConquista = "Novato",
                Objetivo = "Entre no app pela primeira vez",
                Recompensa = 10,
                IsFinish = true,
                Cor = "Red"
            });
            Conquistas.Add(new Conquista
            {
                CodConquista = 2,
                NomeConquista = "Comprometimento",
                Objetivo = "Entre no app 5 vezes em um único dia",
                Recompensa = 20,
                IsFinish = false,
                Cor = "Gray"
            });
            Conquistas.Add(new Conquista
            {
                CodConquista = 3,
                NomeConquista = "Viciado",
                Objetivo = "Entre no app 10 vezes em um único dia",
                Recompensa = 30,
                IsFinish = false,
                Cor = "Gray"
            });
            Conquistas.Add(new Conquista
            {
                CodConquista = 4,
                NomeConquista = "Mestre da Criação",
                Objetivo = "Crie o primeiro baralho",
                Recompensa = 50,
                IsFinish = false,
                Cor = "Red"
            });
        }
        public List<Conquista> PegarConquistas(){
            return Conquistas;
        }
    }
}
