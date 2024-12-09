using CardMind.Models;
using CardMind.Popups;
using CardMind.Services.Navigation;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.ViewModels
{
    public partial class PerfilViewModel:ObservableObject
    {
        [ObservableProperty]
        public string nomeBaralho = "Nome do Baralho";
        [ObservableProperty]
        public ObservableCollection<string> nomes = new ObservableCollection<string>();
        [ObservableProperty]
        public string itemSelecionado = "nenhum";
        [ObservableProperty]
        public string item = "a";
        [ObservableProperty]
        public string nomeUsuario = "";
        [ObservableProperty]
        public string email = "";
        
        private INavigationService navigationService;

        [RelayCommand]
        public async Task ShowPopup()
        {
            var popup = new CriarBaralho();
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(popup);
            if (result != null) {
                var baralho = (Baralho)result;
                Nomes.Add(baralho.NomeBaralho);
            }
        }
        [RelayCommand]
        public async Task Logout()
        {
            Preferences.Set("statusUsuario", "deslogado");
            await navigationService.NavigateToAsync("//Login");
        }

        public PerfilViewModel(INavigationService navigationService)
        {
            Nomes.Add(NomeBaralho);
            this.navigationService = navigationService;

        }
        [RelayCommand]
        private async Task BaralhoSelecionado(string nome)
        {
            ItemSelecionado = nome;
            Item = "a";

            await navigationService.NavigateToAsync("Baralho",
                new Dictionary<string, object>
                {
                    {"nome", nome},
                });
        }
        [RelayCommand]
        public void Appearing()
        {
            NomeUsuario = Preferences.Default.Get("nomeUsuario","guest");
            Email = Preferences.Default.Get("emailUsuario", "guest");
        }
    }
}
