using Microsoft.Maui.Controls.Maps;
using Project2024.LocalBase;
using Project2024.SqlServer;
using System.Net;

namespace Project2024.Views;

public partial class CreateOrJoinPage : ContentPage
{
    private readonly Route route;
    public CreateOrJoinPage()
    {
        InitializeComponent();

        route = new()
        {
            StartPin = UserRoute.GetStartPin(),
            EndPin = UserRoute.GetEndPin(),
            Time = UserRoute.GetTime(),
            Owner = UserRoute.GetOwner()
        };

        Pin pin1 = new()
        {
            Label = "Початок маршруту",
            Type = PinType.Place,
            Location = new Location(route.StartPin.Latitude, route.StartPin.Longitude)
        };

        Pin pin2 = new()
        {
            Label = "Кінець маршруту",
            Type = PinType.Place,
            Location = new Location(route.EndPin.Latitude, route.EndPin.Longitude)
        };

        map.Pins.Add(pin1);
        map.Pins.Add(pin2);
    }

    

    private void BtnJoinToRoute_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SimilarRoutesPage));
    }

    private void BtnCreateRoute_Clicked(object sender, EventArgs e)
    {
        

        RoutesRepository.AddRoute(route);

        DisplayAlert("Маршрут додано", "Щоб переглянути маршрут відкрийте меню", "OK");

        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}