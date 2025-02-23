using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class OpenTimePage : ContentPage
{
	public OpenTimePage()
	{
		InitializeComponent();
        this.BindingContext = new OpenTimeViewModel();
    }
}