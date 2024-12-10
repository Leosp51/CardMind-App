using CardMind.Models;
using CardMind.Services.LocalServices;
using CardMind.Services.Navigation;

namespace CardMind.Views;
[QueryProperty(nameof(Carta), "CartaPergunta")]
[QueryProperty(nameof(Estilo), "Estilo")]
public partial class CartaPerguntaView : ContentPage
{
	public string nomeImg = "white_background.png";
	public string borderColor = "#f00";
	public string color = "#f00";
	public string textColor = "#000";
	public string btnColor = "#f00";
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
			if(estiloBaralho.NomeEstilo != "Padrão")
            {
				imgFundo.Source = estiloBaralho.BackgroundImg;
				borderBox.Stroke = Color.FromArgb(estiloBaralho.BorderColor);
				frContent.BorderColor = Color.FromArgb(estiloBaralho.BorderColor);
				lbNomeCarta.TextColor = Color.FromArgb(estiloBaralho.TextColor);
				frContent.BackgroundColor = Color.FromRgba(estiloBaralho.Color);
				lbPergunta.TextColor = Color.FromArgb(estiloBaralho.TextColor);
				btn.TextColor = Color.FromArgb(estiloBaralho.TextColor);
				if (estiloBaralho.NomeEstilo == "Cósmico")
					btn.BackgroundColor = Color.FromArgb("#808080");
				else
					btn.BackgroundColor = Color.FromArgb(estiloBaralho.Color);
			}
		}
	}
	private string nome = "";
	public string Nome
	{
		get => nome;
		set
		{
			nome = value;

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
			},
			{
				"Estilo", estiloBaralho
			}
		});
    }
    protected override void OnAppearing()
    {
        header.Dinheiro = sistemaRecompensa.Dinheiro.ToString();
        header.Trofeus = sistemaRecompensa.Trofeus.ToString();
    }

	private async void Voltar(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}