namespace Project2024;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
        Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
        Routing.RegisterRoute(nameof(RouteCreationPage), typeof(RouteCreationPage));
        Routing.RegisterRoute(nameof(CreateOrJoinPage), typeof(CreateOrJoinPage));
        Routing.RegisterRoute(nameof(SimilarRoutesPage), typeof(SimilarRoutesPage));
    }
}
