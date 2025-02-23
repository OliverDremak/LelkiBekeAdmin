using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class ContactMessagesPage : ContentPage
{
	public ContactMessagesPage()
	{
		InitializeComponent();
		this.BindingContext = new ContactMessagesViewModel();
    }
}