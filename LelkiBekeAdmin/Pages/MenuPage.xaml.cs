using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
		this.BindingContext = new MenuViewModel();
    }
}