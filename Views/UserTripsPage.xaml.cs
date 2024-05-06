using Project2024.LocalBase;
using Project2024.Server;

namespace Project2024.Views;

public partial class UserTripsPage : ContentPage
{

    private List<Route> OwnRoutes;
    private List<Route> ActiveRoutes;
    private List<Route> CompletedRoutes;
    public UserTripsPage()
    {
        InitializeComponent();

        OwnRoutes = new List<Route>();

        ActiveRoutes = new List<Route>();

        CompletedRoutes = new List<Route>();
    }

    private void BtnDelete_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

    private void BtnOwn_Clicked(object sender, EventArgs e)
    {
        ListOfOwnRoutes.IsVisible = true;
        ListOfActiveRoutes.IsVisible = false;
        ListOfCompletedRoutes.IsVisible = false;
        LoadOwnRoutes();
    }


    private  void BtnActive_Clicked(object sender, EventArgs e)
    {
        ListOfOwnRoutes.IsVisible = false;
        ListOfActiveRoutes.IsVisible = true;
        ListOfCompletedRoutes.IsVisible = false;
        LoadActiveRoutes();
    }

    private void BtnCompleted_Clicked(object sender, EventArgs e)
    {
        ListOfOwnRoutes.IsVisible = false;
        ListOfActiveRoutes.IsVisible = false;
        ListOfCompletedRoutes.IsVisible = true;
    }
    private void BtnCancelMyTrip_Clicked(object sender, EventArgs e)
    {
        var routeToRemove = (sender as ImageButton)?.BindingContext as Route;

        if (routeToRemove != null)
        {
            UserRoute.RemoveMyRoute(routeToRemove);

            LoadOwnRoutes();

            UserRoute.AddLastRoute(routeToRemove);
        }
    }

    private void BtnCompleteTrip_Clicked(object sender, EventArgs e)
    {

    }

    private void LoadOwnRoutes()
    {
        OwnRoutes = UserRoute.GetMyRoutes();

        ListOfOwnRoutes.ItemsSource = OwnRoutes;
    }

    private void LoadActiveRoutes()
    {
        ActiveRoutes = UserRoute.GetActiveRoutes();

        ListOfActiveRoutes.ItemsSource = ActiveRoutes;
    }
    private void LoadCompletedRoutes()
    {
        CompletedRoutes = UserRoute.GetLastRoutes();

        ListOfCompletedRoutes.ItemsSource = CompletedRoutes;
    }

    private void BtnDisconnect_Clicked(object sender, EventArgs e)
    {
        var routeToDisconnect = (sender as ImageButton)?.BindingContext as Route;

        if(routeToDisconnect != null)
        {
            RoutesRepository.RemoveFellowTraveler(routeToDisconnect.Owner.Name, UserRepository.GetUserByPhone(UserRoute.GetOwner().Phone));
        }
    }


}