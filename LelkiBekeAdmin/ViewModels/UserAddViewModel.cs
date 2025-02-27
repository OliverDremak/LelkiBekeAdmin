using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LelkiBekeAdmin.API;
using LelkiBekeAdmin.Classes;
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
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmPassword;

        [ObservableProperty]
        private string role = "waiter";
        public RelayCommand AddWaiterCommand { get; }


        public UserAddViewModel()
        {
            AddWaiterCommand = new RelayCommand(async () => await AddWaiterAsync());
        }



        private async Task AddWaiterAsync()
        {

        }       

        private void ClearEntries()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }
    }
}
