using CardMind.Models;
using CardMind.Services.LocalServices;
using CardMind.Services.Navigation;

namespace CardMind.Views;
[QueryProperty(nameof(Carta), "CartaPergunta")]
public partial class CartaPerguntaView : ContentPage
{
	private CartaPergunta cartaPergunta = new();
	public CartaPergunta Carta
	{
		get => cartaPergunta;
		set
		{
			cartaPergunta = value;
			UpdateUI();
		}
	}
	private EstiloBaralho estiloBaralho = new();
	public EstiloBaralho Estilo
	{
		get => estiloBaralho;
		set
		{
			estiloBaralho = value;

		}
	}

	private SistemaRecompensa sistemaRecompensa = new();
	private INavigationService navigationService;

	public CartaPerguntaView(INavigationService navigationService)
	{
		this.navigationService = navigationService;
		InitializeComponent();
		lbNomeCarta.Text = "";
		lbPergunta.Text = ";";
	}
	void UpdateUI()
	{
		lbNomeCarta.Text = cartaPergunta.NomeCarta;
		lbPergunta.Text = cartaPergunta.Pergunta;
	}
	void UpdateCardEstile()
	{

	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await navigationService.NavigateToAsync("CartaResposta", new Dictionary<string, object>
		{
			{
				"CartaPergunta", Carta
			}
		});
    }
    protected override void OnAppearing()
    {
        header.Dinheiro = sistemaRecompensa.Dinheiro.ToString();
        header.Trofeus = sistemaRecompensa.Trofeus.ToString();
    }
}