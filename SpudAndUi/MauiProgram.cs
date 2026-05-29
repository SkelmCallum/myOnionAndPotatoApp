using Microsoft.Extensions.Logging;
using SpudAndUi.ViewModels;
using SpudAndUi.Views;

namespace SpudAndUi;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<LogPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
