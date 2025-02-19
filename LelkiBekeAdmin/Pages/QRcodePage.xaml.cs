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
    public QRcodePage(QRcodeViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
        qrDrawable = new QRCodeDrawable($"{vm.QRcodeLink}{QRCodeText.Text}");
        qrCanvas.Drawable = qrDrawable;
    }
    public Uri GenerateQRCodeUri(string text)
    {
        string apiUrl = $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={Uri.EscapeDataString(text)}";
        return new Uri(apiUrl);
    }

    private async void OnDownloadQRCodeClicked(object sender, EventArgs e)
    {
        try
        {
            // Get the QR code image from the URL
            var uri = GenerateQRCodeUri($"{this.Url}{QRCodeText.Text}");
            var client = new HttpClient();
            var imageBytes = await client.GetByteArrayAsync(uri);

            //BBtol megkerdezni hogy hogy lehet
           
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
