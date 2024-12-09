using CommunityToolkit.Mvvm.ComponentModel;
using CardMind.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardMind.Services.ApiCardMind;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CardMind.Services.LocalServices;

namespace CardMind.ViewModels
{
    public partial class ConquistasViewModel:ObservableObject
    {
        private ConquistasService conquistasService;
        private SistemaRecompensa sistemaRecompensa;
        private ConquistasLocalService cls;

        [ObservableProperty]
        public ObservableCollection<Conquista> conquistas = new();
        [ObservableProperty]
        public string dinheiroUsuario;
        [ObservableProperty]
        public string trofeusUsuario;

        public ConquistasViewModel(SistemaRecompensa sistema, ConquistasLocalService conquistasLS)
        {
            sistemaRecompensa = sistema;
            cls = conquistasLS;
            PegarConquistas();
        }

        public void PegarConquistas()
        {
            List<Conquista> conquistas = cls.PegarConquistas();
            foreach (var conquista in  conquistas)
            {
                Conquistas.Add(conquista);
            }

        }
        public void HandleGetError()
        {
            
        }
        [RelayCommand]
        public void GanharRecompensa(Conquista conquista)
        {
            if(conquista.Cor == "Red")
            {
                sistemaRecompensa.Receber(conquista.Recompensa);
                sistemaRecompensa.GanharTrofeu();
                Appearing();
                Conquistas.Remove(conquista);
            }
        }
        [RelayCommand]
        public void Appearing()
        {
            DinheiroUsuario = sistemaRecompensa.Dinheiro.ToString();
            TrofeusUsuario = sistemaRecompensa.Trofeus.ToString();
        }


    }
}
