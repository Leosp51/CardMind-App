using CardMind.Models;
using CardMind.Popups;
using CardMind.Services.LocalServices;
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
    public partial class BaralhoViewModel:ObservableObject
    {
        private SistemaRecompensa sistemaRecompensa = new();
        private INavigationService navigationService;
        private UsuarioLocalService usuarioLocalService;

        public Baralho baralho = new();

        [ObservableProperty]
        public string nomeBaralho = "";

        [ObservableProperty]
        public Carta item = new();

        [ObservableProperty]
        public ObservableCollection<Carta> cartas = new();
        [ObservableProperty]
        public string dinheiroUsuario = "";
        [ObservableProperty]
        public string trofeusUsuario = "";

        public BaralhoViewModel(SistemaRecompensa sistemaRecompensa,
                                INavigationService navigationService,
                                UsuarioLocalService usuarioLocalService)
        {
            this.sistemaRecompensa = sistemaRecompensa;
            this.navigationService = navigationService;
            this.usuarioLocalService = usuarioLocalService;
            //colocar serviço de salvamento

        }
        [RelayCommand]
        public async Task CriarCarta()
        {
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(new CriarCarta());
            if (result != null)
            {
                var carta = (Carta)result;
                usuarioLocalService.RemoverBaralho(baralho);
                Cartas.Add(carta);
                baralho.Cartas.Add(carta);
                usuarioLocalService.AdicionarBaralho(baralho);
                

            }
        }
        [RelayCommand]
        public async Task AbrirCarta(Carta card)
        {

            //string route = carta.Tipo == "Pergunta" ? "CartaPergunta" : "CartaTexto";
            //await navigationService.NavigateToAsync(route, new Dictionary<string, object>()
            //{
            //    { route, carta }
            //});
            Item = new Carta();
            var carta = card as Carta;
            if (carta != null)
            {
                string route = carta.Tipo == "Pergunta" ? "CartaPergunta" : "CartaTexto";
                await Shell.Current.GoToAsync(route, new Dictionary<string, object>
            {
                { route, carta },
                {"Estilo", baralho.EstiloBaralho }
            });
            }
        }
        [RelayCommand]
        public void Appearing()
        {
            DinheiroUsuario = sistemaRecompensa.Dinheiro.ToString();
            TrofeusUsuario = sistemaRecompensa.Trofeus.ToString();

        }

        public void CarregarCartas()
        {
            Cartas.Clear();
            List<Carta> cards = baralho.Cartas;
            foreach (Carta carta in cards)
            {
                Cartas.Add(carta);
            }
        }
        [RelayCommand]
        public async Task ApagarCarta(Carta carta)
        {
            var popup = new ConfirmarExclusaoPopup(carta.NomeCarta);
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(popup);
            if (result != null)
            {
                if (result.Equals(true))
                {
                    usuarioLocalService.RemoverBaralho(baralho);
                    baralho.Cartas.Remove(carta);
                    usuarioLocalService.AdicionarBaralho(baralho);
                    CarregarCartas();
                }
            }
        }
        [RelayCommand]
        public async Task Voltar()
        {
            await navigationService.NavigateToAsync("//Menu/Home");
        }
    }
}
