using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class ModifyMenuPage : ContentPage
{
	public ModifyMenuPage()
	{
		InitializeComponent();
		BindingContext = new ModifyMenuViewModel();
    }
}