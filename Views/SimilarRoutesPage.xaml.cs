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

    private void ListOfRoutes_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (ListOfRoutes.SelectedItem != null)
        {
            Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }

    private void BtnDelete_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}