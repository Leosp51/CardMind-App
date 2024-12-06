﻿using CardMind.Models;
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

        [ObservableProperty]
        public string nomeBaralho = "";

        [ObservableProperty]
        public Carta item;

        [ObservableProperty]
        public ObservableCollection<Carta> cartas = new();
        [ObservableProperty]
        public string dinheiroUsuario = "";
        [ObservableProperty]
        public string trofeusUsuario = "";

        public void BaralhosViewModel(SistemaRecompensa sistemaRecompensa, INavigationService navigationService)
        {
            this.sistemaRecompensa = sistemaRecompensa;
            this.navigationService = navigationService;
            //colocar serviço de salvamento

        }
        [RelayCommand]
        public async Task CriarCarta()
        {
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(new CriarCarta());
            if (result != null)
            {
                var carta = (Carta)result;
                Cartas.Add(carta);

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
                { route, carta }
            });
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