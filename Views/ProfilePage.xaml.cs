using Project2024.LocalBase;

namespace Project2024.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();

		lblphone.Text = UserRoute.GetOwner().Phone;
	}

    private void BtnDelete_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(MenuPage));
    }

    private void PersonalDateBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(PersonalDatePage));
    }

    private void SettingsBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SettingsPage));
    }
}