using CommunityToolkit.Mvvm.ComponentModel;
using LelkiBekeAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.ViewModels
{

    public partial class StatViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<StatModel> salesData;

        public StatViewModel()
        {
            SalesData = new ObservableCollection<StatModel>
        {
            new StatModel { Category = "January", Value = 1200 },
            new StatModel { Category = "February", Value = 1500 },
            new StatModel { Category = "March", Value = 1800 },
            new StatModel { Category = "April", Value = 1700 },
            new StatModel { Category = "May", Value = 2000 },
            new StatModel { Category = "June", Value = 2100 },
        };
        }
    }
}
