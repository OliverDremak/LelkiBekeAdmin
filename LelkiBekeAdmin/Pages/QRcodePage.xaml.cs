using LelkiBekeAdmin.ViewModels;
using ZXing;
using System.IO;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Storage;
using LelkiBekeAdmin.Classes;



namespace LelkiBekeAdmin.Pages;

public partial class QRcodePage : ContentPage
{
    private QRCodeDrawable qrDrawable;

    private string Url;
    public QRcodePage()
    {
        InitializeComponent();
        var qrViewModel = new QRcodeViewModel();
        this.BindingContext = qrViewModel;
        //qrDrawable = new QRCodeDrawable($"{qrViewModel.QRcodeLink}{QRCodeText.Text}");
        //qrCanvas.Drawable = qrDrawable;
    }
    public Uri GenerateQRCodeUri(string text)
    {
        string apiUrl = $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={Uri.EscapeDataString(text)}";
        return new Uri(apiUrl);
    }

    private async void OnDownloadQRCodeClicked(object sender, EventArgs e)
    {
        if (true) // This should be a command in the view model!!
        {
            try
            {
                // Get the QR code image from the URL
                var uri = GenerateQRCodeUri($"{this.Url}{QRCodeText.Text}");
                var client = new HttpClient();
                var imageBytes = await client.GetByteArrayAsync(uri);

                // Save it to a file
                string fileName = $"QRCode_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                //await File.WriteAllBytesAsync(filePath, imageBytes);

                // Share the saved image
                await Share.Default.RequestAsync(new ShareFileRequest
                {
                    Title = "Download QR Code",
                    //File = new ShareFile()
                });

                await DisplayAlert("Success", $"QR Code saved to gallery successfully!", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to download QR Code: {ex.Message}", "OK");
            }
        }
    }
}
