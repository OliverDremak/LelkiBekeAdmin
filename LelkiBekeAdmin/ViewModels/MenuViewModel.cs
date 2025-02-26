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
using System.Text.Json;
using LelkiBekeAdmin.API;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        public ObservableCollection<FoodItem> MenuItems { get; private set; } = new ObservableCollection<FoodItem>();
        public ObservableCollection<Category> Categories { get; private set; } = new ObservableCollection<Category>();
        public ObservableCollection<FoodItem> FilteredMenuItems { get; set; } = new ObservableCollection<FoodItem>();
        public FoodItem SelectedItem { get; set; }
        public ICommand NavigateToModifyCommand { get; }
        public ICommand RemoveItemCommand { get; }
        public ICommand CategorySelectedBtnCommand { get; }
        public ICommand AddItemCommand { get; }

        public MenuViewModel()
        {
            LoadMenuItems();
            AddItemCommand = new RelayCommand(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(ModifyMenuPage)}");
            });
            RemoveItemCommand = new RelayCommand<FoodItem>(async item => await RemoveItem(item));
            CategorySelectedBtnCommand = new RelayCommand<Category>(async item =>
            {
                CategorySelectedBtn(item);
            });
            NavigateToModifyCommand = new RelayCommand<FoodItem>(async item =>
            {
                var json = JsonSerializer.Serialize(item);
                await Shell.Current.GoToAsync($"//{nameof(ModifyMenuPage)}?menuItem={Uri.EscapeDataString(json)}");
            });
        }

        private async Task RemoveItem(FoodItem item)
        {
            MenuItems.Remove(item);
            FilteredMenuItems.Remove(item);
        }

        private void CategorySelectedBtn(Category category)
        {
            IEnumerable<FoodItem> items;
            if (category.Name != "All")
            {
                items = MenuItems.Where(x => x.category_name == category.Name);
                FilteredMenuItems.Clear();
                foreach (var item in items)
                {
                    FilteredMenuItems.Add(item);
                }
            }
            else
            {
                FilteredMenuItems.Clear();
                foreach (var item in MenuItems)
                {
                    FilteredMenuItems.Add(item);
                }
            }
        }

        private async void LoadMenuItems()
        {
            var menuItems = await BackEndApi.GetMenu<List<FoodItem>>();
            if (menuItems != null)
            {
                foreach (var item in menuItems)
                {
                    MenuItems.Add(item);
                    FilteredMenuItems.Add(item);
                }
                var categories = menuItems.Select(x => x.category_name).Distinct();
                Categories.Add(new Category { Name = "All" });
                foreach (var category in categories)
                {
                    Categories.Add(new Category { Name = category });
                }
            }
        }
    }
}