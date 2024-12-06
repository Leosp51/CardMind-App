using CardMind.Services.Navigation;
using CardMind.ViewModels;

namespace CardMind.Views;

public partial class Login : ContentPage
{
	private readonly LoginViewModel _viewModel;
	public Login(LoginViewModel viewModel)
	{
		BindingContext = _viewModel = viewModel;
		InitializeComponent();
	}

}