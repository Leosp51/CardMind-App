using CardMind.Models;
using CardMind.Popups;
using CardMind.Services.LocalServices;
using CardMind.Services.Navigation;
using CardMind.ViewModels;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace CardMind.Views;
[QueryProperty(nameof(Nome), "nomeBaralho")]
public partial class BaralhoView : ContentPage
{
	private BaralhoViewModel baralhoViewModel;

	private string nome;
	public string Nome
	{
		get => nome;
		set
		{
			baralhoViewModel.NomeBaralho = nome =  value;
			BindingContext = baralhoViewModel;
		}
	}

	public BaralhoView( BaralhoViewModel baralhoViewModel)
	{
		InitializeComponent();
		BindingContext = baralhoViewModel;
		this.baralhoViewModel = baralhoViewModel;
	}

    private async void CollectionCartas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

        
    }
}