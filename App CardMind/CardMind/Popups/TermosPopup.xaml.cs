using CommunityToolkit.Maui.Views;

namespace CardMind.Popups;

public partial class TermosPopup : Popup
{
	public TermosPopup()
	{
		InitializeComponent();
	}
	private void Sair(object sender, EventArgs e)
	{
		Close();
	}
}