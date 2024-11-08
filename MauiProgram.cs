using Microsoft.Extensions.Logging;
using APISocialAPP.Models;
using MudBlazor.Services;



namespace APISocialAPP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<User>();
            builder.Services.AddSingleton<DeviceInfoService>();
            builder.Services.AddScoped<CsrfService>();
            builder.Services.AddBlazorBootstrap();
            builder.Services.AddMudServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            builder.Services.AddHttpClient();
            

            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Services.AddBlazorWebView();
#endif

            return builder.Build();
        }
    }
}
