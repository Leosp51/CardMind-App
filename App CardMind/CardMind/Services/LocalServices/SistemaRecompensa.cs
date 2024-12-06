using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Services.LocalServices
{
    public class SistemaRecompensa
    {
        private static int dinheiro=100;
        private static int trofeus=0;
        public int Dinheiro { get => dinheiro; set=> dinheiro = value; }
        public int Trofeus { get => trofeus; set => trofeus = value; }

        public SistemaRecompensa()
        {
            //Serviços
        }

        public bool ComprarEstilo(int valorEstilo)
        {
            if (Dinheiro - valorEstilo>= 0)
            {
                Dinheiro -= valorEstilo;
                return true;
            }
            else
                return false;
        }
        public void Receber(int recompensa)
        {
            Dinheiro += recompensa;
        }
        public void GanharTrofeu()
        {
            Trofeus += 1;
        }
    }
}
