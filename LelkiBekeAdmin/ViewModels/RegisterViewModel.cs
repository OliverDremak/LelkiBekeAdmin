using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using LelkiBekeAdmin.Pages;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class RegisterViewModel
    {
        public ICommand NavigateToMenuCommand { get; }
        public ICommand NavigateToLoginCommand { get; }

        public RegisterViewModel()
        {
            NavigateToMenuCommand = new RelayCommand(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(MenuPage)}");
            });
            NavigateToLoginCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            });
        }
    }
}
