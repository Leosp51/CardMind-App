using CardMind.ViewModels;

namespace CardMind.Views;

public partial class CadastroView : ContentPage
{
	public CadastroView(CadastroViewModel cadastroViewModel)
	{
		InitializeComponent();
		BindingContext = cadastroViewModel;
	}

}