using Project2024.Services;

namespace Project2024.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage()
	{
		InitializeComponent();
    }
    private void BtnService_Clicked(object sender, EventArgs e)
    {
        AuthService.LogOut();
        System.Environment.Exit(0);
    }

    private async void BtnTrips_Clicked(object sender, EventArgs e)
    {
       await Shell.Current.GoToAsync(nameof(UserTripsPage));
    }
}
