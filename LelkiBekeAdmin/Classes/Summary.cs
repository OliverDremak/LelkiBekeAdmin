using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Classes
{
    public class Summary
    {
        [JsonPropertyName("total_orders")]
        public int TotalOrders { get; set; }

        [JsonPropertyName("total_revenue")]
        public string TotalRevenue { get; set; }

        [JsonPropertyName("average_order_value")]
        public string AverageOrderValue { get; set; }
    }
}
