﻿using Microsoft.Maui.Controls.Maps;
using Project2024.LocalBase;
using Project2024.Server;
using Project2024.ViewModels;

namespace Project2024.Views;

public partial class MainPage : ContentPage
{

    private readonly MainPageViewModel _viewModel;

    public double StartLatitude = 0;
    public double StartLongitude = 0;
    public double EndLatitude = 0;
    public double EndLongitude = 0;
    public int PinCount = 0;

    public MainPage()
    {
        InitializeComponent();

        _viewModel = new MainPageViewModel();
        BindingContext = _viewModel;
    }
    private void BtbMenu_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(MenuPage));
    }

    private void BtbBack_Clicked(object sender, EventArgs e)
    {
        _viewModel.Main();
        DeletePins();
        DeletePins();
        PinCount = 0;
    }


    private void BtnStart_Clicked(object sender, EventArgs e)
    {
        _viewModel.CreatingRoute();
    }

    private void BtnSave_Clicked(object sender, EventArgs e)
    {
        UserRoute.SetStartPin(StartLatitude, StartLongitude);

        UserRoute.SetEndPin(EndLatitude, EndLongitude);

        _viewModel.CreateOrJoin();

    }

    private void BtnDeletePin_Clicked(object sender, EventArgs e)
    {
        DeletePins();
    }

    private void DeletePins()
    {
        if (PinCount == 1)
        {
            Map.Pins.RemoveAt(0);

            PinCount--;
        }
        else if (PinCount == 2)
        {
            Map.Pins.RemoveAt(1);

            PinCount--;
        }
        else
        {
            return;
        }
    }

    private async void BtnJoinToRoute_Clicked(object sender, EventArgs e)
    {
        if (PinCount == 2)
        {
            _viewModel.Main();
            DeletePins();
            DeletePins();
            PinCount = 0;

            await Shell.Current.GoToAsync(nameof(SimilarRoutesPage));
        }
        else
        {
            await DisplayAlert("Маршрут не створено", "оберіть звідки і куди ви хочете їхати", "OK");

            _viewModel.CreatingRoute();
            DeletePins();
        }
    }

    private async void BtnCreateRoute_Clicked(object sender, EventArgs e)
    {
        if (PinCount == 2)
        {

            var tripType = await DisplayActionSheet("Тип поїздки", "Скасувати", null, "Таксі", "Автомобіль");

            string time = "", date = "";
            string carBrand = "Taxi";

            if (tripType == "Автомобіль")
            {
                carBrand = await DisplayPromptAsync("Марка автомобіля", "Введіть марку автомобіля", "OK", "Скасувати");
                time = await DisplayPromptAsync("Час", "введіть час", maxLength: 5, keyboard: Keyboard.Email, placeholder: "11:11");
                date = await DisplayPromptAsync("Дата", "введіть дату", maxLength: 5, keyboard: Keyboard.Numeric, placeholder: "01.01");
            }
            else if (tripType == "Таксі")
            {
                time = await DisplayPromptAsync("Час", "введіть час", maxLength: 5, keyboard: Keyboard.Email, placeholder: "11:11");
                date = await DisplayPromptAsync("Дата", "введіть дату", maxLength: 5, keyboard: Keyboard.Numeric, placeholder: "01.01");

            }

            if (!string.IsNullOrEmpty(time) && !string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(carBrand))
            {
                if (time[2] != ':' || date[2] != '.')
                {
                    await DisplayAlert("Маршрут не створено", "Неправильно введений час або дата, введіть ще раз", "OK");
                    return;
                }
            }
            else
            {
                await DisplayAlert("Маршрут не створено", "дані не введено", "OK");
                return;
            }

            Route route = new()
            {
                StartPin = UserRoute.GetStartPin(),
                EndPin = UserRoute.GetEndPin(),
                Time = time,
                Date = GetMonth(date),
                Transport = carBrand,
                Owner = UserRoute.GetOwner(),
                fellow_travelers = new()
            };

            UserRoute.AddMyRoute(route);

            RoutesRepository.AddRoute(route);

            await DisplayAlert("Маршрут додано", "Щоб переглянути маршрут відкрийте меню", "OK");

            _viewModel.Main();
            DeletePins();
            DeletePins();
            PinCount = 0;

        }
        else
        {
            await DisplayAlert("Маршрут не створено", "оберіть звідки і куди ви хочете їхати", "OK");

            _viewModel.CreatingRoute();
            DeletePins();
        }

    }

    private void Map_MapClicked_1(object sender, MapClickedEventArgs e)
    {
        if (_viewModel.IsCreatingRoute == true)
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

                Map.Pins.Add(FirstPin);

                LblHint.Text = "Оберіть кінець маршруту";

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

                Map.Pins.Add(SecondPin);

                LblHint.Text = "Збережіть поїздку";

            }
            else
            {
                return;
            }
        }

    }
    private static string GetMonth(string date)
    {

        string[] parts = date.Split('.');

        if (parts.Length != 2)
        {
            return "Некоректний формат дати";
        }

        string[] months = {
        "січня", "лютого", "березня", "квітня",
        "травня", "червня", "липня", "серпня",
        "вересня", "жовтня", "листопада", "грудня"
    };


        if (!int.TryParse(parts[1], out int month) || month < 1 || month > 12)
        {
            return "Некоректний місяць";
        }
        string monthString = months[month - 1];

        return $"{parts[0]}{" "}{monthString}";

    }
}
