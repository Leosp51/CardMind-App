﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CardMind.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardMind.Services.ApiCardMind;
using CardMind.Services.LocalServices;
using CommunityToolkit.Maui.Views;
using CardMind.Popups;

namespace CardMind.ViewModels
{
    public partial class LojaViewModel: ObservableObject
    {
        private EstilosLocalService estilosLocalService;
        private UsuarioLocalService usuarioLocalService;
        private SistemaRecompensa sistemaRecompensa = new();

        [ObservableProperty]
        public ObservableCollection<EstiloBaralho> estilos;
        [ObservableProperty]
        public string dinheiroUsuario;
        [ObservableProperty]
        public string trofeusUsuario;

        public LojaViewModel(SistemaRecompensa sistemaRecompensa, EstilosLocalService estilosLocalService, UsuarioLocalService usuarioLocalService)
        {
            this.sistemaRecompensa = sistemaRecompensa;
            this.estilosLocalService = estilosLocalService;
            this.usuarioLocalService = usuarioLocalService;
            Estilos = new();
            DinheiroUsuario = "0";
            TrofeusUsuario = "0";
            PegarEstilos();
            List<EstiloBaralho> est = estilosLocalService.estiloBaralhos;
            foreach (var item in est)
            {
                Estilos.Add(item);
            }
        }

        public void PegarEstilos()
        {
        }
        public void HandleGetEstilosError()
        {
            //
        }

        [RelayCommand]
        public async Task ComprarEstilo(EstiloBaralho estilo)
        {
            var popup = new RealizarCompra(estilo.Valor, estilo.NomeEstilo);
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(popup);
            if (result != null)
            {
                if (!result.Equals(false)){
                    Appearing();
                    estilosLocalService.estiloBaralhos.Remove(estilo);
                    usuarioLocalService.AdicionarEstilo(estilo);
                    List<EstiloBaralho> est = estilosLocalService.estiloBaralhos;
                    Estilos.Clear();
                    
                    foreach (var item in est)
                    {
                        Estilos.Add(item);
                    }

                }
                else
                    Shell.Current.CurrentPage.ShowPopup(new CompraInvalida());
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
