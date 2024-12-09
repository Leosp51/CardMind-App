using CommunityToolkit.Maui.Views;

namespace CardMind.Popups;

public partial class ConfirmarExclusaoPopup : Popup
{
	public ConfirmarExclusaoPopup()
	{
		InitializeComponent();
	}
	public ConfirmarExclusaoPopup(string nomeEntidade)
	{
		InitializeComponent();
		spNome.Text = nomeEntidade;
	}
	private void Apagar(object sender, EventArgs e)
	{
		Close(true);
	}
	private void NaoApagar(object sender, EventArgs e)
	{
		Close();
	}
}