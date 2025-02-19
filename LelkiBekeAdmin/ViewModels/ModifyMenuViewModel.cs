using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using LelkiBekeAdmin.Pages;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class ModifyMenuViewModel : ObservableObject
    {
        public ICommand NavigateToMenuCommand { get; }

        public ModifyMenuViewModel()
        {
            NavigateToMenuCommand = new RelayCommand(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(MenuPage)}");
            });
        }
    }
}
