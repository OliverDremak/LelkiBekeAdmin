using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
    }
}