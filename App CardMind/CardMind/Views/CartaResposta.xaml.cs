using CardMind.Models;
using CardMind.Services.LocalServices;

namespace CardMind.Views;
[QueryProperty(nameof(Carta), "CartaPergunta")]
public partial class CartaResposta : ContentPage
{
    private CartaPergunta cartaPergunta;
    public CartaPergunta Carta
    {
        get => cartaPergunta;
        set
        {
            cartaPergunta = value;
            UpdateUI();
        }
    }
    private SistemaRecompensa sistemaRecompensa = new();

    void UpdateUI()
    {
        lbNomeCarta.Text = cartaPergunta.NomeCarta;
        lbResposta.Text = cartaPergunta.Resposta;
    }

    public CartaResposta()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {

        header.Dinheiro = sistemaRecompensa.Dinheiro.ToString();
        header.Trofeus = sistemaRecompensa.Trofeus.ToString();
    }
}