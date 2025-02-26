using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LelkiBekeAdmin.API;
using LelkiBekeAdmin.Classes;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class TableViewModel : ObservableObject
    {
        public ObservableCollection<TableItem> TableItems { get; set; } = new ObservableCollection<TableItem>();
        public ICommand RemoveItemCommand { get; }
        public ICommand ModifyItemCommand { get; }
        public ICommand AddItemCommand { get; }
        public ICommand SaveCommand { get; }

        public TableViewModel()
        {
            LoadTableItems();
            RemoveItemCommand = new RelayCommand<TableItem>(async item => RemoveItem(item));
            ModifyItemCommand = new RelayCommand<TableItem>(async item => ModifyItem(item));
            AddItemCommand = new RelayCommand<TableItem>(async item => AddItem(item));
            SaveCommand = new RelayCommand<TableItem>(async item =>  Save(item));
        }
        private void Save(TableItem table)
        {
            var item = TableItems.FirstOrDefault(x => x.id == table.id);
            if (item != null)
            {
                item.table_number = table.table_number;
                item.qr_code_url = table.qr_code_url;
                item.is_available = table.is_available;
            }
        }
        private void AddItem(TableItem item)
        {
            //Ok
        }

        private void ModifyItem(TableItem item)
        {

        }
        private void RemoveItem(TableItem item)
        {
            TableItems.Remove(item);
        }
        private async void LoadTableItems()
        {
            var tableItems = await BackEndApi.GetTables<List<TableItem>>();
            if (tableItems != null)
            {
                foreach (var item in tableItems)
                {
                    TableItems.Add(item);
                }
            }
        }
    }
}
