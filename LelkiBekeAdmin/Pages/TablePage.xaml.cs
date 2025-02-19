using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class TablePage : ContentPage
{
	public TablePage()
	{
		InitializeComponent();
		this.BindingContext = new TableViewModel();
    }
}