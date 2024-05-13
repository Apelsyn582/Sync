using Project2024.LocalBase;
using Project2024.Server;

namespace Project2024.Views;

public partial class PersonalDatePage : ContentPage
{

    public PersonalDatePage()
    {
        InitializeComponent();

        NameEntry.Text = UserRoute.GetOwner().Name;

        PhoneEntry.Text = UserRoute.GetOwner().Phone;

    }



    private void BtnDelete_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnSave_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(NameEntry.Text))
        {
            if (UserRepository.IfNameIsBooked(NameEntry.Text))
            {
                DisplayAlert("Помилка", "Таке ім'я вже є", "OK");
            }
            else
            {
                UserRoute.AddName(NameEntry.Text);

                UserRepository.AddUser(UserRoute.GetOwner());

                Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
        }
        else
        {
            DisplayAlert("Помилка", "Введіть ім'я", "OK");
        }

    }
}