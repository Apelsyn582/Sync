using Project2024.LocalBase;
using Project2024.Server;

namespace Project2024.Views;

public partial class SimilarRoutesPage : ContentPage
{
    public SimilarRoutesPage()
    {
        InitializeComponent();

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadUsers();
    }

    private void LoadUsers()
    {
        Location start = new(UserRoute.GetStartPin().Latitude, UserRoute.GetStartPin().Longitude);

        Location end = new(UserRoute.GetEndPin().Latitude, UserRoute.GetEndPin().Longitude);

        var routes = new ObservableCollection<Route>(RoutesRepository.GetListWithFellowTravelers(start, end));

        ListOfRoutes.ItemsSource = routes;
    }

    private void ListOfRoutes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        ListOfRoutes.SelectedItem = null;

    }

    private async void ListOfRoutes_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item != null)
        {
            var selectedRoute = (Route)e.Item;
            await Shell.Current.GoToAsync($"{nameof(RouteInformationPage)}?Name={selectedRoute.Owner.Name}");
        }
    }

    private void BtnDelete_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

}