using CardMind.Models;
using CommunityToolkit.Maui.Views;

namespace CardMind.Popups;

public partial class CriarCarta : Popup
{
	public CriarCarta()
	{
		InitializeComponent();
		RadioPergunta.IsChecked = true;
	}
	private void Criar(Object sender, EventArgs e) {
		Carta carta;
		if (RadioPergunta.IsChecked == true)
		{
			carta = new CartaPergunta
			{
				NomeCarta = NomeEntry.Text,
				Pergunta = EntryPergunta.Text,
				Resposta = EntryResposta.Text,
			};
		}
		else
		{
			carta = new CartaTexto
			{
				NomeCarta = NomeEntry.Text,
				Texto =  EdTexto.Text,
			};
		}
		CloseAsync(carta);
		
	}

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs pergunta)
    {
		if (pergunta.Value) {
			OptionPergunta.IsVisible = true;
			OptionTexto.IsVisible = false;
		}
		else{
			OptionPergunta.IsVisible = false;
			OptionTexto.IsVisible = true;
		}
    }
}