
namespace Project2024.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler ?PropertyChanged;

        private bool _isCreatingRoute;
        private bool _isMainPage;
        private bool _isMainPageBtn;
        private bool _isOtherBtn;
        private bool _isCreateOrJoin;

        public bool IsCreatingRoute
        {
            get => _isCreatingRoute;
            set
            {
                if (_isCreatingRoute != value)
                {
                    _isCreatingRoute = value;
                    OnPropertyChanged(nameof(IsCreatingRoute));
                }
            }
        }

        public bool IsOtherBtn
        {
            get => _isOtherBtn;
            set
            {
                if (_isOtherBtn != value)
                {
                    _isOtherBtn = value;
                    OnPropertyChanged(nameof(IsOtherBtn));
                }
            }
        }

        public bool IsMainPage
        {
            get => _isMainPage;
            set
            {
                if (_isMainPage != value)
                {
                    _isMainPage = value;
                    OnPropertyChanged(nameof(IsMainPage));
                }
            }
        }

        public bool IsMainPageBtn
        {
            get => _isMainPageBtn;
            set
            {
                if (_isMainPageBtn != value)
                {
                    _isMainPageBtn = value;
                    OnPropertyChanged(nameof(IsMainPageBtn));
                }
            }
        }

        public bool IsCreateOrJoin
        {
            get => _isCreateOrJoin;
            set
            {
                if (_isCreateOrJoin != value)
                {
                    _isCreateOrJoin = value;
                    OnPropertyChanged(nameof(IsCreateOrJoin));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPageViewModel()
        {
            IsCreatingRoute = false;
            IsMainPage = true;
            IsMainPageBtn = true;
            IsOtherBtn = false;
            IsCreateOrJoin = false;

        }

        public void CreatingRoute()
        {
            IsMainPage = false;
            IsCreateOrJoin = false;
            IsCreatingRoute = true;
            IsMainPageBtn = false;
            IsOtherBtn = true;
        }

        public void CreateOrJoin()
        {
            IsMainPage = false;
            IsCreateOrJoin = true;
            IsCreatingRoute = false;
            IsMainPageBtn = false;
            IsOtherBtn = true;
        }

        public void Main()
        {
            IsMainPage = true;
            IsCreatingRoute = false;
            IsCreateOrJoin = false;
            IsMainPageBtn = true;
            IsOtherBtn = false;
        }
    }
}

