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
    public partial class TableViewModel : ObservableObject
    {
        public ObservableCollection<TableItem> TableItems { get; private set; } = new ObservableCollection<TableItem>();

        public TableViewModel()
        {
            LoadTableItems();
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
