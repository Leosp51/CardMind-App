using CardMind.Models;
using CardMind.Popups;
using CardMind.Services.LocalServices;
using CardMind.ViewModels;
using CommunityToolkit.Maui.Views;

namespace CardMind.Views;

public partial class LojaView : ContentPage
{
	private LojaViewModel _viewModel;

    public LojaView(LojaViewModel lojaViewModel)
	{
		_viewModel = lojaViewModel;
		InitializeComponent();
        BindingContext = lojaViewModel;
    }

    


}