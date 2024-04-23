using Project2024.LocalBase;
using Project2024.Server;
using Project2024.Services;

namespace Project2024.Views;

public partial class LogInPage : ContentPage
{
    private readonly AuthService _authService;

    private readonly User user;


    public LogInPage(AuthService authService)
    {
        InitializeComponent();

        _authService = authService;

        user = new User();
    }

    public string Phone
    {
        get {return PhoneEntry.Text;}
    }

    public string Password
    {
        get {return PasswordEntry.Text;}
    }


    private void Btn_Sign_In_Clicked(object sender, EventArgs e)
    {
        
            if (UserRepository.IfUserExists(Phone, PasswordHash.CreateHash(Password)))
            {
                _authService.LogIn();

                UserRoute.SetOwner(UserRepository.GetUserByPhone(Phone));

                Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                DisplayAlert("�������", "����� �������� ��� ������ ������������", "OK");
            }
        
    }

    private void Btn_Sign_UP_Clicked(object sender, EventArgs e)
    {
            if (!(UserRepository.IfPhoneIsBooked(Phone)))
            {
                if (PhoneAndPasswordCheck())
                {   
                    user.Phone = Phone;
                    user.Password = PasswordHash.CreateHash(Password);

                    UserRoute.SetOwner(user);

                    _authService.LogIn();

                    Shell.Current.GoToAsync(nameof(PersonalDatePage));
                }
            }
            else
            {
                DisplayAlert("�������", "����� �������� ��������", "OK");
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

