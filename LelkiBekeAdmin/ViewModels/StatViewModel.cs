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
        private Summary summaryData;
        public Summary SummaryData
        {
            get => summaryData;
            set
            {
                if (SetProperty(ref summaryData, value))
                    OnPropertyChanged(nameof(SummaryDisplay));
            }
        }
        public string SummaryDisplay =>
            $"Total Orders: {SummaryData.total_orders}\n" +
            $"Total Revenue: {SummaryData.total_revenue}\n" +
            $"Average Order Value: {SummaryData.average_order_value}";
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
                new StatModel { Category = "July", Value = 2200 },
            };
            SummaryData = new Summary { total_orders = 100, total_revenue = "$1000", average_order_value = "$10" };

        }
    }
}
