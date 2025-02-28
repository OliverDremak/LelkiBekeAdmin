using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LelkiBekeAdmin.API;
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
    public partial class ContactMessagesViewModel : ObservableObject
    {
        public ObservableCollection<ContactMessage> ContactMessages { get; private set; } = new ObservableCollection<ContactMessage>();

        [ObservableProperty]
        private ContactMessage selectedMessage;

        [ObservableProperty]
        private string replyContent = string.Empty;

        [ObservableProperty]
        private bool isReplying = true;

        [ObservableProperty]
        private bool isSending;
        public ICommand ReplayCommand { get; }
        public ContactMessagesViewModel()
        {
            LoadContactMessages();
            ReplayCommand = new RelayCommand<ContactMessage>(async message =>
            {
                SelectedMessage = message;
                IsReplying = true;
                SendEmailAsync(selectedMessage);
            });

        }

        private async void LoadContactMessages()
        {
            var result = await BackEndApi.GetContactMessages<List<ContactMessage>>();
            if (result != null)
            {
                ContactMessages.Clear();
                foreach (var message in result)
                {
                    ContactMessages.Add(message);
                }
            }
        }

        public async Task SendEmailAsync(ContactMessage message)
        {
            string email = message.email;
            string subject = "Replay From InnerPeace";
            string body = $"Replay to:{message.message} Dear:{message.name}";
            string mailto = $"mailto:{email}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";
            try
            {
                await Launcher.OpenAsync(mailto);
            }
            catch (Exception ex)
            {
                // Hiba kezelése (pl. nincs telepítve e-mail alkalmazás)
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }

    }
}