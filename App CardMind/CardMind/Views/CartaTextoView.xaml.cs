using CardMind.Models;
using CardMind.Services.LocalServices;

namespace CardMind.Views;

[QueryProperty(nameof(Carta),"CartaTexto")]
public partial class CartaTextoView : ContentPage
{
	private CartaTexto cartaTexto;
	public CartaTexto Carta
	{
		get => cartaTexto;
		set
		{
			cartaTexto = value;
			UpdateUI();
		}
	}

    private SistemaRecompensa sistemaRecompensa = new();

    public CartaTextoView()
	{
		InitializeComponent();
	}
	void UpdateUI()
	{
		lbNomeCarta.Text = Carta.NomeCarta;
		lbTexto.Text = Carta.Texto;
		
	}
	private void Voltar(object sender, EventArgs e)
	{
		Shell.Current.CurrentPage.Navigation.PopAsync();
	}
    protected override void OnAppearing()
    {
        header.Dinheiro = sistemaRecompensa.Dinheiro.ToString();
        header.Trofeus = sistemaRecompensa.Trofeus.ToString();
    }
}