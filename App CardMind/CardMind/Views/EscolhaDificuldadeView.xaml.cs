using CardMind.Models;
using CardMind.Services.LocalServices;

namespace CardMind.Views;

[QueryProperty(nameof(Carta),"CartaPergunta")]
public partial class EscolhaDificuldadeView : ContentPage
{
	private CartaPergunta carta = new();
	public CartaPergunta Carta
	{
		get => carta;
		set
		{
			carta = value;
			UpdateUI();
		}
	}

	private SistemaRecompensa sistemaRecompensa;

	void UpdateUI()
	{
		lbNomeCarta.Text = carta.NomeCarta;

	}
	public EscolhaDificuldadeView(SistemaRecompensa sistemaRecompensa)
	{
		this.sistemaRecompensa = sistemaRecompensa;
		InitializeComponent();

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		header.Dinheiro = sistemaRecompensa.Dinheiro.ToString();
		header.Trofeus = sistemaRecompensa.Trofeus.ToString();
    }
}