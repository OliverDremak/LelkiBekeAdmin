using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        this.BindingContext = new RegisterViewModel();
    }
}