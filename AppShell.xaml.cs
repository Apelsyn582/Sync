namespace Project2024;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
        Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
        Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
        Routing.RegisterRoute(nameof(SimilarRoutesPage), typeof(SimilarRoutesPage));
        Routing.RegisterRoute(nameof(PersonalDatePage), typeof(PersonalDatePage));
        Routing.RegisterRoute(nameof(RouteInformationPage), typeof(RouteInformationPage));
    }
}
