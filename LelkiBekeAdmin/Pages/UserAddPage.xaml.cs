using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class UserAddPage : ContentPage
{
	public UserAddPage()
	{
		InitializeComponent();
        this.BindingContext = new UserAddViewModel();
    }
}	