using Project2024.LocalBase;
using Project2024.Server;
namespace Project2024.Views;

[QueryProperty(nameof(Name), "Name")]
public partial class RouteInformationPage : ContentPage
{
    private Route route;
	public RouteInformationPage()
	{
		InitializeComponent();

        
    }

    public string Name
    {
        set
        {
            route = RoutesRepository.GetRouteByOwnerName(value);

            BtnTime.Text = route.Date + " " + route.Time; //переробити на назву м≥с€ц€ (Ї номер)

            BtnInformation.Text = route.Transport;

            BtnOwner.Text = route.Owner.Name + " - " + route.Owner.Phone;
        }
    }

    private void BtnDelete_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}