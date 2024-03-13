using Project2024.Services;

namespace Project2024.Views;

public partial class LoadingPage : ContentPage
{
    private readonly AuthService _authService;
    public LoadingPage(AuthService authService)
	{
		InitializeComponent();

        _authService = authService;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await _authService.IsAuthenticatedAsync())
        {
            // код для випадку, коли аутентифікація пройшла успішно
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        else
        {
            // код для випадку, коли аутентифікація не пройшла
            await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
        }
    }
}