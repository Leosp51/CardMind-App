using CardMind.Models;
using CardMind.Popups;
using CardMind.Services.ApiCardMind;
using CardMind.Services.LocalServices;
using CardMind.ViewModels;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace CardMind.Views;

public partial class BaralhosView : ContentPage
{
	public BaralhosView(BaralhosViewModel baralhosViewModel)
	{
		InitializeComponent();
		BindingContext = baralhosViewModel;

	}
}