using Project2024.LocalBase;
using Project2024.Server;

namespace Project2024.Views;

public partial class SimilarRoutesPage : ContentPage
{
    private int selection_count = 0;
    public SimilarRoutesPage()
	{
		InitializeComponent();

    }
    protected override void OnAppearing()
	{
		base.OnAppearing();

        LoadContacts();
    }

    private void LoadContacts()
    {
        Location start = new(UserRoute.GetStartPin().Latitude, UserRoute.GetStartPin().Longitude);

        Location end = new(UserRoute.GetEndPin().Latitude, UserRoute.GetEndPin().Longitude);

        ListOfRoutes.ItemsSource = new ObservableCollection<Route>(RoutesRepository.GetListWithFellowTravelers(start, end));

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

    private void BtnSave_Clicked(object sender, EventArgs e)
    {

    }
}