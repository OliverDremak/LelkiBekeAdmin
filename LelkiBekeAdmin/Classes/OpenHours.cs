using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Classes
{
    public class OpenHours
    {
        public int id { get; set; }
        public string day_of_week { get; set; }
        public string open_time { get; set; }
        public string close_time { get; set; }
        public int is_closed { get; set; }

        public TimeSpan OpenTimeSpan
        {
            get => TimeSpan.TryParse(open_time, out var time) ? time : TimeSpan.Zero;
            set => open_time = value.ToString(@"hh\:mm\:ss");
        }

        // Convert close_time to TimeSpan
        public TimeSpan CloseTimeSpan
        {
            get => TimeSpan.TryParse(close_time, out var time) ? time : TimeSpan.Zero;
            set => close_time = value.ToString(@"hh\:mm\:ss");
        }
    }
}
