using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Classes
{
    public class StatModel
    {
        [JsonPropertyName("sale_date")]
        public DateTime SaleDate { get; set; }

        [JsonPropertyName("total_sales")]
        public string TotalSales { get; set; }
    }
}
