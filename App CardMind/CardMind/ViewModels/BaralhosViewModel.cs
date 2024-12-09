using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using CardMind.Popups;
using CardMind.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardMind.Services.ApiCardMind;
using System.Collections.ObjectModel;
using CardMind.Models;
using CardMind.Services.LocalServices;
using CardMind.Popups;
using CommunityToolkit.Maui.Views;
using CardMind.Services.Navigation;

namespace CardMind.ViewModels
{
    public partial class BaralhosViewModel:ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Baralho> baralhos;
        [ObservableProperty]
        public Baralho item = new Baralho();
        [ObservableProperty]
        public string dinheiroUsuario;
        [ObservableProperty]
        public string trofeusUsuario;


        private readonly IPopupService popupService;
        private UsuarioLocalService usuarioLocalService;
        private SistemaRecompensa sistemaRecompensa = new();
        private INavigationService navigationService;

        [RelayCommand]
        public async Task ShowPopup()
        {
            List<EstiloBaralho> estilos = usuarioLocalService.PegarEstilos();
            var popup = new CriarBaralho(estilos);
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(popup);
            if (result != null)
            {
                var baralho = (Baralho)result;
                Baralhos.Add(baralho);
                usuarioLocalService.AdicionarBaralho(baralho);
            }
        }
        [RelayCommand]
        public async Task BaralhoSelecionado(Baralho baralho)
        {
            Item = new Baralho();
            await navigationService.NavigateToAsync("Baralho",
                new Dictionary<string, object>
                {
                    {"baralho", baralho}
                });
        }
        [RelayCommand]
        public void Apearing()
        {
            DinheiroUsuario = sistemaRecompensa.Dinheiro.ToString();
            TrofeusUsuario = sistemaRecompensa.Trofeus.ToString();
            CarregarBaralho();
        }
        [RelayCommand]
        public async Task RemoverBaralho(Baralho baralho)
        {
            var popup = new ConfirmarExclusaoPopup(baralho.NomeBaralho);
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(popup);
            if(result != null)
            {
                if(result.Equals(true)){
                    usuarioLocalService.RemoverBaralho(baralho);
                    CarregarBaralho();
                }
            }
        }

        public BaralhosViewModel(IPopupService popupService,
                                 UsuarioLocalService usuarioLocalService,
                                 INavigationService navigationService,
                                 SistemaRecompensa sistemaRecompensa) 
        {
            baralhos = new ObservableCollection<Baralho>();
            this.navigationService = navigationService;
            this.popupService = popupService;
            this.sistemaRecompensa = sistemaRecompensa;
            this.usuarioLocalService = usuarioLocalService;


            List<Baralho> bars = usuarioLocalService.PegarBaralhos();
            foreach(var baralho in bars)
            {
                Baralhos.Add(baralho);
            }
        }

        public void CarregarBaralho()
        {
            Baralhos.Clear();
            List<Baralho> bars = usuarioLocalService.PegarBaralhos();
            foreach(var baralho in bars)
            {
                Baralhos.Add(baralho);
            }
        }
    }
}
