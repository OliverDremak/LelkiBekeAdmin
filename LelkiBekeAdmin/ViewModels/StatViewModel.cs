using CommunityToolkit.Mvvm.ComponentModel;
using LelkiBekeAdmin.API;
using LelkiBekeAdmin.Classes;
using LelkiBekeAdmin.Models;
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
        private ObservableCollection<salesDaily> salesDailys = new ObservableCollection<salesDaily>();
        [ObservableProperty]
        private ObservableCollection<TotalSoldItem> menuItems = new ObservableCollection<TotalSoldItem>();

        private SalesSummary summaryData = new SalesSummary();
        public SalesSummary SummaryData
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

        //partial void OnSalesDataChanged(ObservableCollection<StatModel> value)
        //{
        //    ChartDrawable = new ChartDrawable(SalesData);
        //}


        private async void LoadSalesData()
        {
            try
            {
                var result = await BackEndApi.GetDailySales<List<salesDaily>>();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        SalesDailys.Add(new salesDaily
                        {
                            sale_date = item.sale_date,
                            total_sales = item.total_sales
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine($"Error loading sales data: {ex.Message}");
            }
        }

        private async void LoadTopSellingItems()
        {
            try
            {
                var result = await BackEndApi.GetTopSellingItems<List<salesTop_items>>();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        MenuItems.Add(new TotalSoldItem
                        {
                            menu_item = item.menu_item,
                            total_sold = item.total_sold,
                            menu_item_desc = item.menu_item_desc
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine($"Error loading top selling items: {ex.Message}");
            }
        }

        private async void LoadSalesSummary()
        {
            try
            {
                var result = await BackEndApi.GetSalesSummary<List<SalesSummary>>();
                if (result != null && result.Count > 0)
                    SummaryData = new SalesSummary
                    {
                        total_orders = result[0].total_orders,
                        total_revenue = result[0].total_revenue.Split('.')[0],
                        average_order_value = result[0].average_order_value.Split('.')[0]
                    };
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine($"Error loading sales summary: {ex.Message}");
            }
        }
    }
}
