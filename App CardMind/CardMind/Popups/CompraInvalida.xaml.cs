using CommunityToolkit.Maui.Views;

namespace CardMind.Popups;

public partial class CompraInvalida : Popup
{
	public CompraInvalida()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}