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
        
    }

    private async void BtnTrips_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(UserTripsPage));
    }

    private async void BtnProfile_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ProfilePage));
    }
}
