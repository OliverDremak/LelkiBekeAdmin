using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Classes
{
    public class OpenHours
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("day_of_week")]
        public string DayOfWeek { get; set; }

        [JsonPropertyName("open_time")]
        public string OpenTime { get; set; }

        [JsonPropertyName("close_time")]
        public string CloseTime { get; set; }

        [JsonPropertyName("is_closed")]
        public int IsClosed { get; set; }

        public TimeSpan OpenTimeSpan
        {
            get => TimeSpan.TryParse(OpenTime, out var time) ? time : TimeSpan.Zero;
            set => OpenTime = value.ToString(@"hh\:mm\:ss");
        }

        public TimeSpan CloseTimeSpan
        {
            get => TimeSpan.TryParse(CloseTime, out var time) ? time : TimeSpan.Zero;
            set => CloseTime = value.ToString(@"hh\:mm\:ss");
        }
        public bool IsClosedBool
        {
            get => IsClosed == 1;
            set => IsClosed = value ? 1 : 0;
        }
    }
}
