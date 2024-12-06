using CardMind.Services.LocalServices;
using CardMind.ViewModels;

namespace CardMind.Views;

public partial class ConquistasView : ContentPage
{
	private ConquistasViewModel viewModel;


    private SistemaRecompensa sistemaRecompensa = new();
    public ConquistasView(ConquistasViewModel conquistasViewModel)
	{
		viewModel = conquistasViewModel;
		InitializeComponent();
        BindingContext = viewModel;
    }

}