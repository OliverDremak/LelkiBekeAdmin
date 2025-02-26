using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Classes
{
    public class FoodItem
    {
        [JsonPropertyOrder(1)]
        public int id { get; set; }

        [JsonPropertyOrder(2)]
        public string category_name { get; set; }

        [JsonPropertyOrder(3)]
        public string name { get; set; }

        [JsonPropertyOrder(4)]
        public string description { get; set; }

        [JsonPropertyOrder(5)]
        public string price { get; set; }

        [JsonPropertyOrder(6)]
        public string image_url { get; set; }
    }
}
