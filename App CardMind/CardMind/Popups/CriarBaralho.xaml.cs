using CardMind.Models;
using CommunityToolkit.Maui.Views;

namespace CardMind.Popups;

public partial class CriarBaralho : Popup
{

	public CriarBaralho()
	{
		InitializeComponent();
	}
    private void Criar(Object sender, EventArgs e)
    {
        Baralho baralho = new Baralho
        {
            NomeBaralho = NomeEntry.Text,
            CodBaralho = 5,
            CodEstilo = 2,

        };
        CloseAsync(baralho);
    }
}