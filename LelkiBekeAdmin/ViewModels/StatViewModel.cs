using CommunityToolkit.Mvvm.ComponentModel;
using LelkiBekeAdmin.API;
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
        [ObservableProperty]
        private ObservableCollection<TotalSoldItem> menuItems;
        public ChartDrawable ChartDrawable { get; set; }

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
        public string SummaryDisplay => "asd";

        public  StatViewModel()
        {
            LoadSalesData();
            LoadTopSellingItems();
            LoadSalesSummary();
        }

        partial void OnSalesDataChanged(ObservableCollection<StatModel> value)
        {
            ChartDrawable = new ChartDrawable(SalesData);
        }

        private async void LoadSalesData()
        {
           
        }

        private async void LoadTopSellingItems()
        {
           
        }

        private async void LoadSalesSummary()
        {
           
        }
    }
}
