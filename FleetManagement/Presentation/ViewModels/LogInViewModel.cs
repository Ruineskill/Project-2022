#nullable disable
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Presentation.Interfaces;
using System.Net.Http;
using System.Security;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private string _username = string.Empty;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }


        private SecureString _password = new();

        public SecureString Password
        {
            private get => _password;
            set => SetProperty(ref _password, value);
        }


        private bool _isLogInButtonEnabled = true;
        public bool IsLogInButtonEnabled 
        { 
            get => _isLogInButtonEnabled; 
            set => SetProperty(ref _isLogInButtonEnabled, value);
        }

        public LogInViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommand = new RelayCommand(LoginHandler);


        }


        public ICommand LoginCommand { get; }
       

        public async void LoginHandler()
        {
            IsLogInButtonEnabled = false;

            var apiService = App.Current.Services.GetService<IApiSecurityService>();
            bool signedIn = await apiService.SignIn(Username, _password);

            if(signedIn)
            {

                var fleetViewModel = App.Current.Services.GetService<FleetViewModel>();
                _navigationService.Navigate(fleetViewModel);
            }

            IsLogInButtonEnabled = true;

        }
    }
}
