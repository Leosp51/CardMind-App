using CardMind.Models;
using CardMind.Services.Navigation;
using System.Collections.ObjectModel;

namespace CardMind.Views;

public partial class Testes : ContentPage
{
	private INavigationService navigationService;
	private ObservableCollection<Carta> cartas = new ObservableCollection<Carta>();
	public Testes()
	{
		InitializeComponent();
		cartas.Add(new CartaTexto
		{
			NomeCarta = "Trabalho"
			
		});
		CollectionBaralho.ItemsSource = cartas;
		CollectionBaralho.SelectionMode = SelectionMode.Single;
		CollectionBaralho.SelectionChanged += ItemSelected;
	}
	private void ItemSelected(object sender, SelectionChangedEventArgs e)
	{
		var carta = e.CurrentSelection.FirstOrDefault() as Carta;
		string nome = carta.NomeCarta;
		if (carta.Tipo == "Pergunta")
		{
			CartaPergunta cartaPergunta = new CartaPergunta();
			cartaPergunta = e.CurrentSelection.FirstOrDefault() as CartaPergunta;
			navigationService.NavigateToAsync("CartaPergunta", new Dictionary<string, object>
			{
				{
					"cartaPergunta",cartaPergunta
				}
			});
		}
		else
		{
			CartaTexto cartaTexto = e.CurrentSelection.First() as CartaTexto;
			navigationService.NavigateToAsync("CartaTexto", new Dictionary<string, object>
			{
				{
					"cartaTexto", cartaTexto
				}
			});
		}
	}
}