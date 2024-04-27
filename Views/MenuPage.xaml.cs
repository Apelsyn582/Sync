using Project2024.Services;

namespace Project2024.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage()
	{
		InitializeComponent();
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
        AuthService.LogOut();
        System.Environment.Exit(0);
    }
}
