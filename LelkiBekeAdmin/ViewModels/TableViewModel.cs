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
                item.name = table.name;
                item.qr_code_url = table.qr_code_url;
                item.is_avalable = table.is_avalable;
            }
        }
        private void AddItem(TableItem item)
        {
            TableItems.Add(new TableItem { id = 4, name = "Table 4", qr_code_url = "https://www.qrstuff.com/qr1", is_avalable = 0 });
        }

        private void ModifyItem(TableItem item)
        {

        }
        private void RemoveItem(TableItem item)
        {
            TableItems.Remove(item);
        }
        private void LoadTableItems()
        {
            var Examples = new List<TableItem>()
            {
                new TableItem { id = 1, name = "Table 1", qr_code_url = "https://www.qrstuff.com/qr1", is_avalable = 1 },
                new TableItem { id = 2, name = "Table 2", qr_code_url = "https://www.qrstuff.com/qr2", is_avalable = 1 },
                new TableItem { id = 3, name = "Table 3", qr_code_url = "https://www.qrstuff.com/qr3", is_avalable = 1 },
            };
            foreach (var item in Examples)
            {
                TableItems.Add(item);
            }
        }
    }
}
