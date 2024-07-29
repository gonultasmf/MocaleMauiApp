using Microsoft.Extensions.Logging;
using Mocale;
using Mocale.Cache.SQLite;
using System.Globalization;

namespace Project2;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMocale(mocale =>
            {
                mocale.WithConfiguration(config =>
                {
                    config.DefaultCulture = new CultureInfo("en-GB");
                    config.NotFoundSymbol = "?";
                    config.UseExternalProvider = false;
                    
                })
                .UseEmbeddedResources(config =>
                {
                    config.ResourcesPath = "Locales";
                    config.ResourcesAssembly = typeof(App).Assembly;
                    
                })
                .UseSqliteCache(config =>
                {
                    config.UpdateInterval = TimeSpan.FromDays(7);
                });
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Logging.AddDebug();

        builder.Services
            .AddSingleton<App>()
            .AddSingleton<AppShell>()
            .AddScoped<MainPage>();

        return builder.Build();
    }
}
