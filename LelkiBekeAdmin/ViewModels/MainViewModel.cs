using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LelkiBekeAdmin.Pages;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ICommand NavigateToMenuCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        public MainViewModel()
        {
            NavigateToMenuCommand = new RelayCommand(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(MenuPage)}");
            });
            NavigateToRegisterCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
            });
        }
    }
}
