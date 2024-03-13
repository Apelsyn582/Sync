
using Microsoft.Maui.Controls.Maps;
using Project2024.LocalBase;


namespace Project2024.Views;

public partial class RouteCreationPage : ContentPage
{
    public double StartLatitude = 0;

    public double StartLongitude = 0;

    public double EndLatitude = 0;

    public double EndLongitude = 0;

    public int PinCount = 0;
    public RouteCreationPage()
	{
        InitializeComponent();
    }

    private void Map_MapClicked(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e)
    {
        PinCount++;

        if (PinCount == 1) 
        {
            StartLatitude = e.Location.Latitude;

            StartLongitude = e.Location.Longitude;

            Pin FirstPin = new()
            {
                Label = "Початок маршруту",
                Type = PinType.Place,
                Location = new Location(StartLatitude, StartLongitude)
            };

            map.Pins.Add(FirstPin);

            LblNotice.Text = $"Оберіть кінець маршруту";
 
        }
        else if (PinCount == 2)
        {
            EndLatitude = e.Location.Latitude;

            EndLongitude = e.Location.Longitude;

            Pin SecondPin = new()
            {
                Label = "Кінець маршруту",
                Type = PinType.Place,
                Location = new Location(EndLatitude, EndLongitude)
            };

            map.Pins.Add(SecondPin);

            LblNotice.Text = $"Готово! Натисніть зберегти щоб перейти далі";
        }
        else
        {
            return;
        }
    }
    private void BtnDeletePin_Clicked(object sender, EventArgs e)
    {
        if (PinCount == 1)
        {
            map.Pins.RemoveAt(0);

            PinCount--;
        }
        else if (PinCount == 2)
        {
            map.Pins.RemoveAt(1);

            PinCount--;
        }
        else
        {
            return;
        }

    }
    private void BtnSave_Clicked(object sender, EventArgs e)
    {
        UserRoute.SetStartPin(StartLatitude, StartLongitude);

        UserRoute.SetEndPin(EndLatitude, EndLongitude);
    }

    
}