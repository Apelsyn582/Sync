using Project2024.Services;

namespace Project2024.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void LogOutBtn_Clicked(object sender, EventArgs e)
    {
        AuthService.LogOut();
        System.Environment.Exit(0);
    }
}