using Project2024.Services;

namespace Project2024;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiMaps()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();
        builder.Services.AddSingleton<LoadingPage> ();
        builder.Services.AddTransient<AuthService>();
        builder.Services.AddTransient<LogInPage>();
        builder.Services.AddTransient<RouteCreationPage>();
        builder.Services.AddTransient<CreateOrJoinPage>();
        builder.Services.AddTransient<SimilarRoutesPage>();


        return builder.Build();
	}
}
