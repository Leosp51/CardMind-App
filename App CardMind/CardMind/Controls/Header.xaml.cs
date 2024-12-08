using CardMind.Services.LocalServices;

namespace CardMind.Controls;

public partial class Header : ContentView
{
    public static readonly BindableProperty TrofeusProperty = BindableProperty.Create(nameof(Trofeus), typeof(string), typeof(Header), string.Empty);

    public string Trofeus
    {
        get => (string)GetValue(Header.TrofeusProperty);
        set => SetValue(Header.TrofeusProperty, value);
    }

    public static readonly BindableProperty DinheiroProperty = BindableProperty.Create(nameof(Dinheiro), typeof(string), typeof(Header), string.Empty);

    public string Dinheiro
    {
        get => (string)GetValue(Header.DinheiroProperty);
        set => SetValue(Header.DinheiroProperty, value);
    }

    private SistemaRecompensa sistema = new();

    public Header()
	{
		InitializeComponent();
        Trofeus = sistema.Trofeus.ToString();
        Dinheiro = sistema.Dinheiro.ToString();
        string nome = Preferences.Get("nomeUsuario", "Lucas");
        lbNome.Text = "Olá, " + nome;
	}
}