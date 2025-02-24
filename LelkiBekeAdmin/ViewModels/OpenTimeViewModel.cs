using CommunityToolkit.Mvvm.ComponentModel;
using LelkiBekeAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class OpenTimeViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<OpenHours> openingHours;
        public ICommand SaveCommand { get; }

        public OpenTimeViewModel()
        {
            OpeningHours = new ObservableCollection<OpenHours>
            {
                new OpenHours { id = 1, day_of_week = "Monday", open_time = "08:00:00", close_time = "20:00:00", is_closed = 0 },
                new OpenHours { id = 2, day_of_week = "Tuesday", open_time = "08:00:00", close_time = "20:00:00", is_closed = 0 },
                new OpenHours { id = 3, day_of_week = "Wednesday", open_time = "08:00:00", close_time = "20:00:00", is_closed = 0 },
                new OpenHours { id = 4, day_of_week = "Thursday", open_time = "08:00:00", close_time = "20:00:00", is_closed = 0 },
                new OpenHours { id = 5, day_of_week = "Friday", open_time = "08:00:00", close_time = "20:00:00", is_closed = 0 },
                new OpenHours { id = 6, day_of_week = "Saturday", open_time = "08:00:00", close_time = "20:00:00", is_closed = 0 },
                new OpenHours { id = 7, day_of_week = "Sunday", open_time = "08:00:00", close_time = "20:00:00", is_closed = 0 }
            };
            SaveCommand = new Command(async () =>
            {
                SaveChanges();
            });
        }

        private void SaveChanges()
        {
            // Simulate saving (Replace with API request)
            foreach (var hour in OpeningHours)
            {
                Console.WriteLine($"{hour.day_of_week}: {(hour.is_closed == 1 ? "Closed" : $"{hour.open_time} - {hour.close_time}")}");
            }
        }
    }
}
