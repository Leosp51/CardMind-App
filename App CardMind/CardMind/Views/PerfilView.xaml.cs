using CardMind.ViewModels;

namespace CardMind.Views;

public partial class PerfilView : ContentPage
{
	public PerfilView(PerfilViewModel perfilViewModel)
	{
		InitializeComponent();
		BindingContext = perfilViewModel;
	}
}