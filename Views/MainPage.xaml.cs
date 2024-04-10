using Microsoft.Maui.Controls.Maps;
using Project2024.LocalBase;
using Project2024.Server;
using Project2024.Services;
using Project2024.ViewModels;

namespace Project2024.Views;

public partial class MainPage : ContentPage
{
    private readonly AuthService _authService;

    private MainPageViewModel _viewModel;

    

    public double StartLatitude = 0;
    public double StartLongitude = 0;
    public double EndLatitude = 0;
    public double EndLongitude = 0;
    public int PinCount = 0;


    public MainPage(AuthService authService)
	{
		InitializeComponent();

        _viewModel = new MainPageViewModel();
        BindingContext = _viewModel;

        _authService = authService;

    }


    private void BtbMenu_Clicked(object sender, EventArgs e)
    {

    }

    private void LogOut_Clicked(object sender, EventArgs e)
    {
        _authService.LogOut();
        Shell.Current.GoToAsync(nameof(LoadingPage));
    }

    private void map_MapClicked(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e)
    {
        if(_viewModel.IsCreatingRoute == true)
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

            }
            else
            {
                return;
            }
        }
    }

    private void BtnStart_Clicked(object sender, EventArgs e)
    {
        _viewModel.CreatingRoute();
    }

    private void BtnSave_Clicked(object sender, EventArgs e)
    {
        UserRoute.SetStartPin(StartLatitude, StartLongitude);

        UserRoute.SetEndPin(EndLatitude, EndLongitude);

        if(!(string.IsNullOrEmpty(TimeEntry.Text)))
        { 
         if (TimeEntry.Text.Length == 5)
         {
            if (TimeEntry.Text[2] == ':')
            {
                UserRoute.SetTime(TimeEntry.Text);

                _viewModel.CreateOrJoin();
            }
            else
            {
                DisplayAlert("Помилка", "неправильний час", "OK");

                return;
            }
         }
        }
        else
        {
            DisplayAlert("Помилка", "введіть час", "OK");

            return;
        } 

    }

    private void BtnDeletePin_Clicked(object sender, EventArgs e)
    {
        DeletePins();
    }

    private void DeletePins()
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

    private void BtnJoinToRoute_Clicked(object sender, EventArgs e)
    {
        _viewModel.Main();
        DeletePins();
        DeletePins();

        Shell.Current.GoToAsync(nameof(SimilarRoutesPage));

    }

    private void BtnCreateRoute_Clicked(object sender, EventArgs e)
    {
         Route route = new()
         {
             StartPin = UserRoute.GetStartPin(),
             EndPin = UserRoute.GetEndPin(),
             Time = UserRoute.GetTime(),
             Owner = UserRoute.GetOwner()
         };

        RoutesRepository.AddRoute(route);

        DisplayAlert("Маршрут додано", "Щоб переглянути маршрут відкрийте меню", "OK");

        _viewModel.Main();
        DeletePins();
        DeletePins();

        Shell.Current.GoToAsync($"//{nameof(MainPage)}");

    }
}
