using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LelkiBekeAdmin.API;
using LelkiBekeAdmin.Models;
using LelkiBekeAdmin.Pages;
using LelkiBekeAdmin.Storage;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ComfirmPassword { get; set; }
        public ICommand RegisterCommand { get; }
        public ICommand NavigateToLoginCommand { get; }
        public ICommand NavigateToMenuCommand { get; }

        public RegisterViewModel()
        {
            NavigateToLoginCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            });
            NavigateToMenuCommand = new Command(async () =>
            {
                RegisterAsync();
            });
        }

        private async Task RegisterAsync()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ComfirmPassword))
            {
                await Shell.Current.DisplayAlert("Hiányzó adatok", "Kérjük, töltse ki az összes mezőt", "OK");
                return;
            }

            if (Password != ComfirmPassword)
            {
                await Shell.Current.DisplayAlert("Jelszó hiba", "A jelszavak nem egyeznek", "OK");
                return;
            }

            try
            {
                var response = await BackEndApi.Register<RegUser, RegResp>(new RegUser
                {
                    name = Name,
                    email = Email,
                    password = Password,
                    role = "admin"
                });

                if (response != null)
                {
                    await Shell.Current.DisplayAlert("Siker", "Sikeres regisztráció!", "OK");
                    await TokenService.SaveTokenAsync(response.token);
                    await Shell.Current.GoToAsync($"//{nameof(MenuPage)}"); // Go to login page
                }
                else
                {
                    await Shell.Current.DisplayAlert("Hiba", "A regisztráció sikertelen", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hiba", $"Hiba történt: {ex.Message}", "OK");
            }
        }
    }
}
