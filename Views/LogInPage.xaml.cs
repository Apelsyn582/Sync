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
                await DisplayAlert("�������", "����� �������� ��� ������ ������������. ���� �����, ��������� 30 ������.", "OK");
                await Task.Delay(30000);
                Btn_Sign_In.IsEnabled = true;
            }
            else if (fiveInvalidPasswordAttempts == 1)
            {
                Btn_Sign_In.IsEnabled = false;
                await DisplayAlert("�������", "����� �������� ��� ������ ������������. ���� �����, ��������� 2 �������.", "OK");
                await Task.Delay(120000);
                Btn_Sign_In.IsEnabled = true;
            }
            else if (fiveInvalidPasswordAttempts > 1)
            {
                Btn_Sign_In.IsEnabled = false;
                await DisplayAlert("�������", "����� �������� ��� ������ ������������.  ��� ����������� �� 6 ������.", "OK");
                await Task.Delay(360000);
                Btn_Sign_In.IsEnabled = true;
            }

            if (invalidPasswordAttempts == 5)
            {
                fiveInvalidPasswordAttempts++;
                invalidPasswordAttempts = 0;
            }

            await DisplayAlert("�������", "����� �������� ��� ������ ������������", "OK");
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
            await DisplayAlert("�������", "����� �������� ��������", "OK");
        }

    }

    private bool PhoneAndPasswordCheck()
    {
        string specialCharacters = "@!#$%^&*()-_+=|{}[]:;'<>,.?";

        if (string.IsNullOrEmpty(Password))
        {
            DisplayAlert("���� \"������\" ������", "������ ������", "OK");
            return false;
        }

        else if (string.IsNullOrEmpty(Phone))
        {
            DisplayAlert("���� \"����� ��������\" ������", "������ �����", "OK");
            return false;
        }

        else if (Password.Length < 6)
        {
            DisplayAlert("�������", "������ �� ������ ���������� 6 �������", "�����");
            return false;
        }


        else if (!Password.Any(char.IsUpper) || !Password.Any(char.IsLower))
        {
            DisplayAlert("�������", "������ �� ������ ��������� ���� � ��������� � �������� ������, ����� � �������", "OK");
            return false;
        }


        else if (!Password.Any(char.IsDigit))
        {
            DisplayAlert("�������", "������ �� ������ ��������� ���� � ��������� � �������� ������, ����� � �������", "OK");
            return false;
        }

        else if (!Password.Any(c => specialCharacters.Contains(c)))
        {
            DisplayAlert("�������", "������ �� ������ ��������� ���� � ��������� � �������� ������, ����� � �������", "OK");
            return false;
        }


        else if (Phone[0] != '+' || Phone[1] != '3' || Phone[2] != '8' || Phone[3] != '0' || Phone.Length != 13)
        {
            DisplayAlert("�������", "����������� �������� �����, ������ �� ���", "�����");
            return false;
        }

        else
        {
            return true;
        }

    }
}

