using CardMind.Models;
using CardMind.Services.LocalServices;

namespace CardMind.Views;

[QueryProperty(nameof(Carta),"CartaTexto")]
[QueryProperty(nameof(Estilo), "Estilo")]
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
                lbTexto.TextColor = Color.FromArgb(estiloBaralho.TextColor);
                btn.TextColor = Color.FromArgb(estiloBaralho.TextColor);
                if (estiloBaralho.NomeEstilo == "Cósmico")
                    btn.BackgroundColor = Color.FromArgb("#808080");
                else
                    btn.BackgroundColor = Color.FromArgb(estiloBaralho.Color);
            }
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
    private async void VoltarSeta(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}