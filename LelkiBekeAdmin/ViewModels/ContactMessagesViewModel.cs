using CommunityToolkit.Mvvm.ComponentModel;
using LelkiBekeAdmin.API;
using LelkiBekeAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.ViewModels
{
    public partial class ContactMessagesViewModel : ObservableObject
    {
        //public ObservableCollection<ContactMessage> ContactMessages { get; set; } = new ObservableCollection<ContactMessage>();
        public ObservableCollection<ContactMessage> ContactMessages { get; private set; } = new ObservableCollection<ContactMessage>();

        public ContactMessagesViewModel()
        {
            LoadContactMessages();
        }

        private async void LoadContactMessages()
        {
            var result = await BackEndApi.GetContactMessages<List<ContactMessage>>();
            if (result != null)
            {
                ContactMessages = new ObservableCollection<ContactMessage>(result);
            }
        }
    }
}
