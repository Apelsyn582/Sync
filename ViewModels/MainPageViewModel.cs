using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace Project2024.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isCreatingRoute;
        private bool _isMainPage;
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
            IsCreateOrJoin = false;
        }

        public void CreatingRoute()
        {
            IsMainPage = false;
            IsCreateOrJoin = false;
            IsCreatingRoute = true;
        }

        public void CreateOrJoin()
        {
            IsMainPage = false;
            IsCreateOrJoin = true;
            IsCreatingRoute = false;
        }

        public void Main()
        {
            IsMainPage = true;
            IsCreatingRoute = false;
            IsCreateOrJoin = false;
        }
    }
}

