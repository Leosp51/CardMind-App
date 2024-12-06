namespace CardMind.Views.Templates;

public partial class BaralhoTemplate : ContentView
{
	public string NomeBaralho { get; set; }
	public BaralhoTemplate()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("Baralho?nomeBaralho=");
    }
}