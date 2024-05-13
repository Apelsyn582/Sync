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

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadUsers();
    }

    public string Name
    {
        set
        {
            route = RoutesRepository.GetRouteByOwnerName(value);

            if(route != null) 
            {
                BtnTime.Text = route.Date + " " + route.Time;

                BtnInformation.Text = route.Transport;

                BtnOwner.Text = route.Owner.Name + " - " + route.Owner.Phone;
            }           
        }
        get
        {
            return route.Owner.Name;
        }
    }
    private void LoadUsers()
    {
        ListOffellow_travelers.ItemsSource = null;
        ListOffellow_travelers.ItemsSource = new ObservableCollection<User>(RoutesRepository.GetFellowTravelers(Name));
    }

    private void BtnDelete_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

    private void BtnFollow_Clicked(object sender, EventArgs e)
    {
        RoutesRepository.AddFellowTraveler(Name, new User()
        {
            Name = UserRoute.GetOwner().Name,
            Password = UserRoute.GetOwner().Password,
            Phone = UserRoute.GetOwner().Phone,
        }
        );

        UserRoute.AddActiveRoute(route);

        DisplayAlert("Ви приєдналися до поїздки", "Перейдіть в меню щоб побачити деталі поїздки", "OK");

        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }


}

