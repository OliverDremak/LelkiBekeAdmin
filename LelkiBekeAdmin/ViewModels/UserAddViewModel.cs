using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LelkiBekeAdmin.API;
using LelkiBekeAdmin.Classes;
using LelkiBekeAdmin.Models;
using LelkiBekeAdmin.Pages;
using LelkiBekeAdmin.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class UserAddViewModel : ObservableObject
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ComfirmPassword { get; set; }

        [ObservableProperty]
        private string role = "waiter";
        public RelayCommand AddWaiterCommand { get; }


        public UserAddViewModel()
        {
            AddWaiterCommand = new RelayCommand(async () => await RegisterAsync());
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
                    ClearEntries();
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

        private void ClearEntries()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            ComfirmPassword = string.Empty;
        }
    }
}
