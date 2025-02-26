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

namespace LelkiBekeAdmin.ViewModels
{
    public partial class ModifyMenuViewModel : ObservableObject, IQueryAttributable
    {
        private FoodItem NotUpdated { get; set; }
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
                await Shell.Current.GoToAsync($"//{nameof(MenuPage)}");
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
                }
            }
            else
            {
                SelectedItem = new FoodItem();
            }
        }

        private async Task SaveItem()
        {
            if (SelectedItem != null)
            {
                try
                {
                    var result = await BackEndApi.ModifyMenuItemById(SelectedItem);
                    if (result != null)
                    {
                        // Handle success (e.g., navigate back to the menu page)
                        await Shell.Current.GoToAsync($"//{nameof(MenuPage)}");
                    }
                    else
                    {
                        // Handle failure (e.g., show an error message)
                        await Application.Current.MainPage.DisplayAlert("Error", "Failed to save the menu item.", "OK");
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle HttpRequestException
                    await Application.Current.MainPage.DisplayAlert("Network Error", $"An error occurred while sending the request: {ex.Message}", "OK");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    await Application.Current.MainPage.DisplayAlert("Error", $"An unexpected error occurred: {ex.Message}", "OK");
                }
            }
        }
    }
}
