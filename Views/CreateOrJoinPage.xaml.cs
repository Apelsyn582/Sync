using Project2024.LocalBase;
using Project2024.SqlServer;

namespace Project2024.Views;

public partial class CreateOrJoinPage : ContentPage
{
    private readonly Route route;

    private readonly RoutesRepository routesRepository;

    public CreateOrJoinPage()
	{
		InitializeComponent();

        route = new()
        {
            StartPin = UserRoute.GetStartPin(),
            EndPin = UserRoute.GetEndPin(),
        };

        routesRepository = new RoutesRepository();
    }

    private void BtnJoinToRoute_Clicked(object sender, EventArgs e)
    {
        //логіка-пошук спільних маршрутів
    }

    private void BtnCreateRoute_Clicked(object sender, EventArgs e)
    {
        routesRepository.AddRoute(route);
    }
}