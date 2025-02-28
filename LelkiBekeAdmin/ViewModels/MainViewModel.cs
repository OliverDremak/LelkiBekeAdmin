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
        public string? email { get; set; } = string.Empty;
        public string? password { get; set; } = string.Empty;
        public ICommand NavigateToMenuCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        public bool rememberMe { get; set; }

        public MainViewModel()
        {
            Task.Run(async () => await InitializeAsync());

            NavigateToMenuCommand = new RelayCommand(() =>
            {
                Login();
            });

            NavigateToRegisterCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
            });
        }

        private async Task InitializeAsync()
        {
            if (await SecureStorage.GetAsync("rememberMe") == "true")
            {
                rememberMe = true;
            }
            if (rememberMe)
            {
                email = await SecureStorage.GetAsync("email") ?? string.Empty;
                password = await SecureStorage.GetAsync("password") ?? string.Empty;
            }
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
                    if (rememberMe)
                    {
                        await SecureStorage.SetAsync("rememberMe", "true");
                        await SecureStorage.SetAsync("email", email);
                        await SecureStorage.SetAsync("password", password);
                    }
                    else
                    {
                        // Clear saved credentials
                        SecureStorage.Remove("rememberMe");
                        SecureStorage.Remove("email");
                        SecureStorage.Remove("password");
                    }
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
