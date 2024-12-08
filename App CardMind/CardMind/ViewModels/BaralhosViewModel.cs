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
        public string item = "a";
        [ObservableProperty]
        public ObservableCollection<string> nomesBaralhos = new ObservableCollection<string>();
        [ObservableProperty]
        public string dinheiroUsuario;
        [ObservableProperty]
        public string trofeusUsuario;

        public Dictionary<string,Baralho> data = new Dictionary<string,Baralho>();

        private readonly IPopupService popupService;
        private UsuarioLocalService usuarioLocalService;
        private SistemaRecompensa sistemaRecompensa = new();
        private INavigationService navigationService;

        [RelayCommand]
        public async Task ShowPopup()
        {
            var popup = new CriarBaralho();
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(popup);
            if (result != null)
            {
                var baralho = (Baralho)result;
                Baralhos.Add(baralho);
                NomesBaralhos.Add(baralho.NomeBaralho);
                data.TryAdd(baralho.NomeBaralho, baralho);
            }
        }
        [RelayCommand]
        public async Task BaralhoSelecionado(string nomeBaralho)
        {
            Item = "a";
            await navigationService.NavigateToAsync("Baralho",
                new Dictionary<string, object>
                {
                    {"nomeBaralho", nomeBaralho}
                });
        }
        [RelayCommand]
        public void Apearing()
        {
            DinheiroUsuario = sistemaRecompensa.Dinheiro.ToString();
            TrofeusUsuario = sistemaRecompensa.Trofeus.ToString();
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
        }

    }
}
