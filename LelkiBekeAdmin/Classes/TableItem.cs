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
        public string name { get; set; }
        public string qr_code_url { get; set; }
        public int is_avalable { get; set; }
        public bool is_available => is_avalable == 1;
        public string color => is_avalable == 1 ? "Green" : "Red";
    }
}
