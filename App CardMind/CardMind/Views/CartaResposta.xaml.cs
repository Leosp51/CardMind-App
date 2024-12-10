using CardMind.Models;
using CardMind.Services.LocalServices;
using CardMind.Services.Navigation;

namespace CardMind.Views;
[QueryProperty(nameof(Carta), "CartaPergunta")]
[QueryProperty(nameof(Estilo), "Estilo")]
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
    private EstiloBaralho estiloBaralho = new();
    public EstiloBaralho Estilo
    {
        get => estiloBaralho;
        set
        {
            estiloBaralho = value;
            if (estiloBaralho.NomeEstilo != "Padrão")
            {
                imgFundo.Source = estiloBaralho.BackgroundImg;

                borderBox.Stroke= Color.FromArgb(estiloBaralho.BorderColor);
                frContent.BorderColor = Color.FromArgb(estiloBaralho.BorderColor);
                lbNomeCarta.TextColor = Color.FromArgb(estiloBaralho.TextColor);
                frContent.BackgroundColor = Color.FromRgba(estiloBaralho.Color);
                lbResposta.TextColor = Color.FromArgb(estiloBaralho.TextColor);
                btn.TextColor = Color.FromArgb(estiloBaralho.TextColor);
                if (estiloBaralho.NomeEstilo == "Cósmico")
                    btn.BackgroundColor = Color.FromArgb("#808080");
                else
                    btn.BackgroundColor = Color.FromArgb(estiloBaralho.Color);
            }
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
            { "CartaPergunta", Carta },
            { "Estilo", estiloBaralho }
        });
    }
    private async void Voltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}