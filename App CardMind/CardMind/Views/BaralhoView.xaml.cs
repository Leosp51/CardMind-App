using CardMind.Models;
using CardMind.Popups;
using CardMind.Services.LocalServices;
using CardMind.Services.Navigation;
using CardMind.ViewModels;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace CardMind.Views;
[QueryProperty(nameof(Baralho), "baralho")]
public partial class BaralhoView : ContentPage
{
	private BaralhoViewModel baralhoViewModel;

	private Baralho baralho = new();
	public Baralho Baralho
	{
		get => baralho;
		set
		{
			baralho =  value;
            baralhoViewModel.NomeBaralho = baralho.NomeBaralho;
			baralhoViewModel.baralho = baralho;
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