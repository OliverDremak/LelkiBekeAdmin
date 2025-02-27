using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Models
{
    public class SalesSummary
    {
        public int total_orders { get; set; }
        public string total_revenue { get; set; }
        public string average_order_value { get; set; }
    }

}
