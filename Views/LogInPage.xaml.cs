using Project2024.Services;

namespace Project2024.Views;

public partial class LogInPage : ContentPage
{
    private readonly AuthService _authService;
    public LogInPage(AuthService authService)
	{
		InitializeComponent();

        _authService = authService;
    }

    private void BtnLogIn_Clicked(object sender, EventArgs e)
    {
        _authService.LogIn();

        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}