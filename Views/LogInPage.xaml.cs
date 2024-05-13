using Project2024.LocalBase;
using Project2024.Server;
using Project2024.Services;

namespace Project2024.Views;

public partial class LogInPage : ContentPage
{
    private User user;

    private int invalidPasswordAttempts = 0;
    private int fiveInvalidPasswordAttempts = -1;
    public LogInPage()
    {
        InitializeComponent();

        user = new User();
    }

    public string Phone
    {
        get { return PhoneEntry.Text; }
    }

    public string Password
    {
        get { return PasswordEntry.Text; }
    }


    private async void Btn_Sign_In_Clicked(object sender, EventArgs e)
    {

        user = UserRepository.GetUserByPhone(Phone);

        if (UserRepository.IfUserExists(Phone) && PasswordHash.Authenticate(Password, user.Password, user.Salt))
        {
            AuthService.LogIn();

            UserRoute.SetOwner(UserRepository.GetUserByPhone(Phone));

            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        else
        {
            invalidPasswordAttempts++;

            if (fiveInvalidPasswordAttempts == 0)
            {
                Btn_Sign_In.IsEnabled = false;
                await DisplayAlert("Помилка", "Номер телефону або пароль неправильний. Будь ласка, зачекайте 30 секунд.", "OK");
                await Task.Delay(30000);
                Btn_Sign_In.IsEnabled = true;
            }
            else if (fiveInvalidPasswordAttempts == 1)
            {
                Btn_Sign_In.IsEnabled = false;
                await DisplayAlert("Помилка", "Номер телефону або пароль неправильний. Будь ласка, зачекайте 2 хвилини.", "OK");
                await Task.Delay(120000);
                Btn_Sign_In.IsEnabled = true;
            }
            else if (fiveInvalidPasswordAttempts > 1)
            {
                Btn_Sign_In.IsEnabled = false;
                await DisplayAlert("Помилка", "Номер телефону або пароль неправильний.  Вас заблоковано на 6 хвилин.", "OK");
                await Task.Delay(360000);
                Btn_Sign_In.IsEnabled = true;
            }

            if (invalidPasswordAttempts == 5)
            {
                fiveInvalidPasswordAttempts++;
                invalidPasswordAttempts = 0;
            }

            await DisplayAlert("Помилка", "Номер телефону або пароль неправильний", "OK");
        }

    }

    private async void Btn_Sign_UP_Clicked(object sender, EventArgs e)
    {
        if (!(UserRepository.IfUserExists(Phone)))
        {
            if (PhoneAndPasswordCheck())
            {
                user.Phone = Phone;
                user.Password = PasswordHash.HashPassword(Password, out byte[] salt);
                user.Salt = Convert.ToHexString(salt);

                UserRoute.SetOwner(user);

                AuthService.LogIn();

                await Shell.Current.GoToAsync(nameof(PersonalDatePage));
            }
        }
        else
        {
            await DisplayAlert("Помилка", "Номер телефону зайнятий", "OK");
        }

    }

    private bool PhoneAndPasswordCheck()
    {
        string specialCharacters = "@!#$%^&*()-_+=|{}[]:;'<>,.?";

        if (string.IsNullOrEmpty(Password))
        {
            DisplayAlert("Поле \"Пароль\" порожнє", "Введіть пароль", "OK");
            return false;
        }

        else if (string.IsNullOrEmpty(Phone))
        {
            DisplayAlert("Поле \"Номер телефону\" порожнє", "Введіть номер", "OK");
            return false;
        }

        else if (Password.Length < 6)
        {
            DisplayAlert("Помилка", "Пароль має містити щонайменше 6 символів", "Добре");
            return false;
        }


        else if (!Password.Any(char.IsUpper) || !Password.Any(char.IsLower))
        {
            DisplayAlert("Помилка", "Пароль має містити комбінацію букв у верхньому і нижньому регістрі, чисел і символів", "OK");
            return false;
        }


        else if (!Password.Any(char.IsDigit))
        {
            DisplayAlert("Помилка", "Пароль має містити комбінацію букв у верхньому і нижньому регістрі, чисел і символів", "OK");
            return false;
        }

        else if (!Password.Any(c => specialCharacters.Contains(c)))
        {
            DisplayAlert("Помилка", "Пароль має містити комбінацію букв у верхньому і нижньому регістрі, чисел і символів", "OK");
            return false;
        }


        else if (Phone[0] != '+' || Phone[1] != '3' || Phone[2] != '8' || Phone[3] != '0' || Phone.Length != 13)
        {
            DisplayAlert("Помилка", "Неправильно введений номер, введіть ще раз", "Добре");
            return false;
        }

        else
        {
            return true;
        }

    }
}

