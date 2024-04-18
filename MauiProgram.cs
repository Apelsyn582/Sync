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
				fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
				fonts.AddFont("Montserrat-Semibold.ttf", "MontserratSemibold");
			});

		builder.Services.AddTransient<MainPage>();
        builder.Services.AddSingleton<LoadingPage> ();
        builder.Services.AddTransient<AuthService>();
        builder.Services.AddTransient<LogInPage>();
        builder.Services.AddTransient<SimilarRoutesPage>();
        builder.Services.AddTransient<PersonalDatePage>();
        builder.Services.AddTransient<RouteInformationPage>();


        return builder.Build();
	}
}
