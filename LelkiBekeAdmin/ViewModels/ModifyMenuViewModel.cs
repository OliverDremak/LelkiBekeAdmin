using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using LelkiBekeAdmin.Pages;
using System.Text.Json;
using LelkiBekeAdmin.Classes;
using LelkiBekeAdmin.API;
using LelkiBekeAdmin.Models;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class ModifyMenuViewModel : ObservableObject, IQueryAttributable
    {
        private FoodItem NotUpdated { get; set; }
        private bool isNew { get; set; } = true;
        private FoodItem _selectedItem;
        public FoodItem SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
        private string _title = "Add Menu Item";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public ICommand NavigateToMenuCommand { get; }
        public ICommand SaveItemCommand { get; }

        public ModifyMenuViewModel()
        {
            NavigateToMenuCommand = new RelayCommand(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(MenuPage)}?refresh=true");
            });

            SaveItemCommand = new RelayCommand(async () => await SaveItem());
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("menuItem"))
            {
                var encodedJson = query["menuItem"]?.ToString();
                if (!string.IsNullOrEmpty(encodedJson))
                {
                    var json = Uri.UnescapeDataString(encodedJson);
                    SelectedItem = JsonSerializer.Deserialize<FoodItem>(json);
                    Title = "Edit Menu Item";
                    NotUpdated = JsonSerializer.Deserialize<FoodItem>(json);
                    isNew = false;
                }
            }
            else
            {
                SelectedItem = new FoodItem();
            }
        }

        private async Task SaveItem()
        {
            if (isNew)
            {
                NewMenuItem newItem = new NewMenuItem
                {
                    //name = SelectedItem.name,
                    //price = SelectedItem.price,
                    //category_id = SelectedItem.category_name,
                    //description = SelectedItem.description,
                    //image = SelectedItem.image
                };
                var result = await BackEndApi.CreateNewMenuItem<NewMenuItem, FoodItem>(newItem);
                if (result != null)
                {
                    await Shell.Current.DisplayAlert(Shell.Current.CurrentPage.Title, "Item created successfully", "OK");
                    await Shell.Current.GoToAsync($"//{nameof(MenuPage)}");
                }
            }
            else
            {
                ModifyMenuItem modifyItem = new ModifyMenuItem
                {
                    id = SelectedItem.id,
                    name = SelectedItem.name,
                    description = SelectedItem.description,
                    image_url = SelectedItem.image_url,
                    price = int.Parse(SelectedItem.price),
                    category_id = SelectedItem.category_id,
                };
                var result = await BackEndApi.ModifyMenuItemById<ModifyMenuItem, object>(modifyItem);
                if (result != null)
                {
                    await Shell.Current.DisplayAlert(Shell.Current.CurrentPage.Title, "Item updated successfully", "OK");
                    await Shell.Current.GoToAsync($"//{nameof(MenuPage)}?refresh=true");
                }
                else
                {
                    await Shell.Current.DisplayAlert(Shell.Current.CurrentPage.Title, "Item update failed", "OK");
                }

            }
        }
    }
}
