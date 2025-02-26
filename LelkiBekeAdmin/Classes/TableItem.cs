using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Classes
{
    public class TableItem
    {
        public int id { get; set; }
        public string table_number { get; set; }
        public string qr_code_url { get; set; }
        public int is_available { get; set; }
    }
}
