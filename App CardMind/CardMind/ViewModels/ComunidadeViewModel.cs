using CardMind.Services.LocalServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.ViewModels
{
    public partial class ComunidadeViewModel:ObservableObject
    {
        private SistemaRecompensa sistemaRecompensa;

        [ObservableProperty]
        public string dinheiroUsuario;
        [ObservableProperty]
        public string trofeusUsuario;

        public ComunidadeViewModel(SistemaRecompensa sistemaRecompensa)
        {
            this.sistemaRecompensa = sistemaRecompensa;
        }
        [RelayCommand]
        public void Appearing()
        {
            DinheiroUsuario = sistemaRecompensa.Dinheiro.ToString();
            TrofeusUsuario = sistemaRecompensa.Trofeus.ToString();
        }
    }
}
