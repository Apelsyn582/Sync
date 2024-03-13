namespace Project2024.Views;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();

	}

    private void BtnFrom_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(RouteCreationPage));
    }

    private void BtbMenu_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnTo_Clicked(object sender, EventArgs e)
    {

    }
}
