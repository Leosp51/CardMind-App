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

        [ObservableProperty]
        public ObservableCollection<Conquista> conquistas = new();
        [ObservableProperty]
        public string dinheiroUsuario;
        [ObservableProperty]
        public string trofeusUsuario;

        public ConquistasViewModel(SistemaRecompensa sistema)
        {
            sistemaRecompensa = sistema;
            PegarConquistas();
        }

        public void PegarConquistas()
        {
            //colocar o serviço no lugar do código abaixo
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
                Objetivo = "Crie 20 baralhos",
                Recompensa = 50,
                IsFinish = false,
                Cor = "Red"
            });
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
