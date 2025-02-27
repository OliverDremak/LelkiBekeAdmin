using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LelkiBekeAdmin.API;
using LelkiBekeAdmin.Models;
using LelkiBekeAdmin.Pages;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public string email { get; set; }
        public string password { get; set; }
        public ICommand NavigateToMenuCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        public MainViewModel()
        {
            NavigateToMenuCommand = new RelayCommand(async () =>
            {
                Login();
            });
            NavigateToRegisterCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
            });
        }

        private async void Login()
        {
            var response = await BackEndApi.Login<LoginSend, LoginRespRoot>(new LoginSend
            {
                email = email,
                password = password
            });

            if (response != null)
            {
                if (response.message == "Sikeres bejelentkezés")
                {                   
                    await Shell.Current.GoToAsync($"//{nameof(MenuPage)}");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Hiba", "Hibás email vagy jelszó", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Hiba", "Hibás email vagy jelszó", "OK");
            }
        }
    }
}
