using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LelkiBekeAdmin.Classes;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        public ObservableCollection<FoodItem> MenuItems { get; private set; } = new ObservableCollection<FoodItem>();

        public MenuViewModel()
        {
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            var Examples = new List<FoodItem>()
            {
                new FoodItem { Id = 1, Category_name = "Pizza", Name = "Margherita", Description = "Tomato, mozzarella, basil", Price = "6.50", Image_url = "https://www.pizzapizza.ca/wp-content/uploads/2019/06/PP_Web_2019_06_13_0001.jpg" },
                new FoodItem { Id = 2, Category_name = "Pizza", Name = "Pepperoni", Description = "Tomato, mozzarella, pepperoni", Price = "7.50", Image_url = "https://www.pizzapizza.ca/wp-content/uploads/2019/06/PP_Web_2019_06_13_0001.jpg" },
                new FoodItem { Id = 3, Category_name = "Pizza", Name = "Hawaiian", Description = "Tomato, mozzarella, ham, pineapple", Price = "8.50", Image_url = "https://www.pizzapizza.ca/wp-content/uploads/2019/06/PP_Web_2019_06_13_0001.jpg" },
            };
            foreach (var item in Examples)
            {
                MenuItems.Add(item);
            }
        }
    }
}