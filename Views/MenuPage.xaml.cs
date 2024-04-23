using Project2024.Services;

namespace Project2024.Views;

public partial class MenuPage : ContentPage
{
    private readonly AuthService _authService;
    public MenuPage(AuthService authService)
	{
		InitializeComponent();

        _authService = authService;
    }

    private void BtnProfile_Clicked(object sender, EventArgs e)
    {
        
    }
    private void BtnCity_Clicked(object sender, EventArgs e)
    {

    }
    private void BtnTrips_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnNews_Clicked(object sender, EventArgs e)
    {

    }
    private void BtnHelp_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnService_Clicked(object sender, EventArgs e)
    {
        _authService.LogOut();
        Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
    }
}
