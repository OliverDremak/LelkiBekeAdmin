using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is IQueryAttributable queryAttributable)
        {
            queryAttributable.ApplyQueryAttributes(new Dictionary<string, object> { { "refresh", true } });
        }
    }
}