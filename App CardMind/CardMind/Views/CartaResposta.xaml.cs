using CardMind.Models;
using CardMind.Services.LocalServices;
using CardMind.Services.Navigation;

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
    private INavigationService navigationService;

    void UpdateUI()
    {
        lbNomeCarta.Text = cartaPergunta.NomeCarta;
        lbResposta.Text = cartaPergunta.Resposta;
    }

    public CartaResposta(INavigationService navigationService)
	{
        this.navigationService = navigationService;
		InitializeComponent();
        
	}

    protected override void OnAppearing()
    {

        header.Dinheiro = sistemaRecompensa.Dinheiro.ToString();
        header.Trofeus = sistemaRecompensa.Trofeus.ToString();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await navigationService.NavigateToAsync("EscolhaDificuldade", new Dictionary<string, object>
        {
            { "CartaPergunta", Carta }
        });
    }
}