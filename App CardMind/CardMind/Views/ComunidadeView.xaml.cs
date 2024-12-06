using CardMind.Services.LocalServices;
using CardMind.ViewModels;

namespace CardMind.Views;

public partial class ComunidadeView : ContentPage
{
	private SistemaRecompensa sistema = new();
	public ComunidadeView(ComunidadeViewModel comunidadeViewModel)
	{
		InitializeComponent();
		BindingContext = comunidadeViewModel;
	}
}