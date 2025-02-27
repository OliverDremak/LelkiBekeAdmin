using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LelkiBekeAdmin.API;
using LelkiBekeAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class OpenTimeViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<OpenHours> _openingHours;
        public ICommand SaveItemCommand { get; }

        public OpenTimeViewModel()
        {
            _openingHours = new ObservableCollection<OpenHours>();
            LoadOpenHours();
            SaveItemCommand = new RelayCommand<OpenHours>(async item =>
            {

            });
        }

        private async void LoadOpenHours()
        {
            var result = await BackEndApi.GetOpenHours<List<OpenHours>>();
            if (result != null)
            {
                OpeningHours = new ObservableCollection<OpenHours>(result);
            }
        }
    }
}
