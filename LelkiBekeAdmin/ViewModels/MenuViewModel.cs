using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LelkiBekeAdmin.Classes;
using LelkiBekeAdmin.Pages;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        public ObservableCollection<FoodItem> MenuItems { get; private set; } = new ObservableCollection<FoodItem>();
        public FoodItem SelectedItem { get; set; }
        public ICommand NavigateToModifyCommand { get; }
        public ICommand RemoveItemCommand { get; }

        public MenuViewModel()
        {
            LoadMenuItems();
            NavigateToModifyCommand = new RelayCommand(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(ModifyMenuPage)}");
            });
            RemoveItemCommand = new RelayCommand<FoodItem>(async item => await RemoveItem(item));
        }
        private async Task RemoveItem(FoodItem item)
        {
            MenuItems.Remove(item);
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