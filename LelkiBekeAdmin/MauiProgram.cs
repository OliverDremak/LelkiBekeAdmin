using CommunityToolkit.Maui;
using LelkiBekeAdmin.Pages;
using LelkiBekeAdmin.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace LelkiBekeAdmin
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa_solid.ttf", "FontAwesome");
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<StatPage>();
            builder.Services.AddSingleton<StatViewModel>();
            builder.Services.AddSingleton<UserAddPage>();
            builder.Services.AddSingleton<UserAddViewModel>();
            builder.Services.AddSingleton<TablePage>();
            builder.Services.AddSingleton<TableViewModel>();
            builder.Services.AddSingleton<MenuPage>();
            builder.Services.AddSingleton<MenuViewModel>();
            builder.Services.AddSingleton<QRcodePage>();
            builder.Services.AddSingleton<QRcodeViewModel>();
            builder.Services.AddSingleton<ModifyMenuPage>();
            builder.Services.AddSingleton<ModifyMenuViewModel>();
            builder.Services.AddSingleton<ContactMessagesPage>();
            builder.Services.AddSingleton<ContactMessagesViewModel>();
            builder.Services.AddSingleton<OpenTimePage>();
            builder.Services.AddSingleton<OpenTimeViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
