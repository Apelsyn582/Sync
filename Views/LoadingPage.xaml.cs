using Project2024.Services;

namespace Project2024.Views;

public partial class LoadingPage : ContentPage
{
    private readonly AuthService _authService;
    public LoadingPage(AuthService authService)
	{
		InitializeComponent();

        _authService = authService;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await _authService.IsAuthenticatedAsync())
        {
            // ��� ��� �������, ���� �������������� ������� ������
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        else
        {
            // ��� ��� �������, ���� �������������� �� �������
            await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
        }
    }
}