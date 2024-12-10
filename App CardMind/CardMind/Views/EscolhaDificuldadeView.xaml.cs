using CardMind.Models;
using CardMind.Services.LocalServices;
using CardMind.Services.Navigation;

namespace CardMind.Views;

[QueryProperty(nameof(Carta),"CartaPergunta")]
[QueryProperty(nameof(Estilo), "Estilo")]
public partial class EscolhaDificuldadeView : ContentPage
{
	private INavigationService navigationService;

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

                borderBox.Stroke = Color.FromArgb(estiloBaralho.BorderColor);
                frContent.BorderColor = Color.FromArgb(estiloBaralho.BorderColor);
                lbNomeCarta.TextColor = Color.FromArgb(estiloBaralho.TextColor);
                frContent.BackgroundColor = Color.FromRgba(estiloBaralho.Color);

                lbTexto1.TextColor = lbTexto2.TextColor = lbTexto3.TextColor = lbTexto4.TextColor = lbTexto5.TextColor = Color.FromArgb(estiloBaralho.TextColor);

                btn.TextColor = Color.FromArgb(estiloBaralho.TextColor);
                if (estiloBaralho.NomeEstilo == "Cósmico")
                    btn.BackgroundColor = Color.FromArgb("#808080");
                else
                    btn.BackgroundColor = Color.FromArgb(estiloBaralho.Color);
            }
        }
    }

    private SistemaRecompensa sistemaRecompensa;

	void UpdateUI()
	{
		lbNomeCarta.Text = carta.NomeCarta;

	}
	public EscolhaDificuldadeView(SistemaRecompensa sistemaRecompensa, INavigationService navigationService)
	{
		this.sistemaRecompensa = sistemaRecompensa;
		this.navigationService = navigationService;
		InitializeComponent();

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		header.Dinheiro = sistemaRecompensa.Dinheiro.ToString();
		header.Trofeus = sistemaRecompensa.Trofeus.ToString();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		//ouros
		((ImageButton)sender).BackgroundColor = Color.FromArgb("#D3D3D3");
		imgBtnCopas.BackgroundColor = Color.FromArgb("#fff");
		imgBtnEspadas.BackgroundColor = Color.FromArgb("#fff");
		imgBtnPaus.BackgroundColor = Color.FromArgb("#fff");
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
		//paus
		((ImageButton)sender).BackgroundColor = Color.FromArgb("#D3D3D3");

        imgBtnCopas.BackgroundColor = Color.FromArgb("#fff");
        imgBtnEspadas.BackgroundColor = Color.FromArgb("#fff");
		imgBtnOuros.BackgroundColor = Color.FromArgb("#fff");
    }

    private void ImageButton_Clicked_2(object sender, EventArgs e)
    {
        //copas

        ((ImageButton)sender).BackgroundColor = Color.FromArgb("#D3D3D3");
        imgBtnEspadas.BackgroundColor = Color.FromArgb("#fff");
        imgBtnPaus.BackgroundColor = Color.FromArgb("#fff");
        imgBtnOuros.BackgroundColor = Color.FromArgb("#fff");
    }

    private void ImageButton_Clicked_3(object sender, EventArgs e)
    {
        //espadas
        ((ImageButton)sender).BackgroundColor = Color.FromArgb("#D3D3D3");

        imgBtnCopas.BackgroundColor = Color.FromArgb("#fff");
        imgBtnPaus.BackgroundColor = Color.FromArgb("#fff");
        imgBtnOuros.BackgroundColor = Color.FromArgb("#fff");
    }

	private async void Concluir(object sender, EventArgs e)
	{
		List<ImageButton> list = new List<ImageButton>();
		list.Add(imgBtnCopas);
		list.Add(imgBtnEspadas);
		list.Add(imgBtnOuros);
		list.Add(imgBtnEspadas);
		await Shell.Current.CurrentPage.Navigation.PopToRootAsync();

	}
    private async void Voltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}