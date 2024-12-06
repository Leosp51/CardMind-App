using CardMind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Services.LocalServices
{
    public class BaralhosLocalService
    {
        public List<Baralho> baralhos = new();
        
        public BaralhosLocalService() {
            string dataDir = FileSystem.Current.AppDataDirectory;
            //pegar dados (baralhos) da pasta do aplicativo
        }

        public void Add(Baralho bar)
        {
            baralhos.Add(bar);
        }
        public void Remove(Baralho bar) {
            baralhos.Remove(bar);
        }
    }
}
