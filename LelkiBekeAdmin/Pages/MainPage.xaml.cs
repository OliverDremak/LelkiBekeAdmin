using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}
