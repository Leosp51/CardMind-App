using CardMind.Models;
using CommunityToolkit.Maui.Views;

namespace CardMind.Popups;

public partial class CriarBaralho : Popup
{
    public List<EstiloBaralho> estilos = new();
	public CriarBaralho()
	{
		InitializeComponent();
        PickerEstilo.SelectedItem = "Padrão";
    }
    public CriarBaralho(List<EstiloBaralho> estilosUsuario)
    {
        InitializeComponent();
        BindingContext = this;
        EstiloBaralho estilo = new EstiloBaralho
        {
            NomeEstilo = "Padrão"
        };
        estilos.Add(estilo);
        foreach (var est in estilosUsuario)
        {
            estilos.Add(est);
        }
        PickerEstilo.ItemsSource = estilos;

        PickerEstilo.SelectedItem = estilo;
    }
    private void Criar(Object sender, EventArgs e)
    {
        var estilo = PickerEstilo.SelectedItem as EstiloBaralho;
        Baralho baralho = new Baralho
        {
            NomeBaralho = NomeEntry.Text,
            CodBaralho = 5,
            CodEstilo = 2,
            EstiloBaralho = estilo
        };
        CloseAsync(baralho);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var popup = new CompraInvalida();
        var result = Shell.Current.CurrentPage.ShowPopupAsync(popup);
    }
}