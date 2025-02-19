using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Classes
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Category_name { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Image_url { get; set; }
    }
}
