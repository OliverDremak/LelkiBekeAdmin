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
            ChartDrawable = new ChartDrawable(SalesData);
        }
        private async void LoadSalesData()
        {
            var salesData = await BackEndApi.GetDailySales<List<StatModel>>();
            if (salesData != null)
            {
                SalesData = new ObservableCollection<StatModel>(salesData);
            }
        }

        private async void LoadTopSellingItems()
        {
            var topSellingItems = await BackEndApi.GetTopSellingItems<List<TotalSoldItem>>();
            if (topSellingItems != null)
            {
                MenuItems = new ObservableCollection<TotalSoldItem>(topSellingItems);
            }
        }

        private async void LoadSalesSummary()
        {
            var salesSummary = await BackEndApi.GetSalesSummary<List<Summary>>();
            if (salesSummary != null)
            {
                SummaryData = salesSummary[0];
            }
        }
    }
}
