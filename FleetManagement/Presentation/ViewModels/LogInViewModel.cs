#nullable disable
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Presentation.Interfaces;
using Presentation.ViewModels.Bases;
using System.Net.Http;
using System.Security;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IApiSecurityService _apiSecurityService;

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


        private bool _isSignInButtonEnabled = true;
        public bool IsSignInButtonEnabled
        { 
            get => _isSignInButtonEnabled; 
            set
            {
                SetProperty(ref _isSignInButtonEnabled, value);
                IsSigningIn = !_isSignInButtonEnabled;
            }
        }

        private bool _isSigningIn = false;
        public bool IsSigningIn
        {
            get => _isSigningIn;
            set => SetProperty(ref _isSigningIn, value);
        }


        public LogInViewModel(INavigationService navigationService, IApiSecurityService apiSecurityService)
        {
            _navigationService = navigationService;
            _apiSecurityService = apiSecurityService;

            LoginCommand = new RelayCommand(LoginHandler);
        }


        public ICommand LoginCommand { get; }
       

        public async void LoginHandler()
        {
            IsSignInButtonEnabled = false;

            bool signedIn = await _apiSecurityService.SignIn(Username, _password);

            if(signedIn)
            {

                var fleetViewModel = App.Current.Services.GetService<FleetViewModel>();
                _navigationService.Navigate(fleetViewModel);
            }

            IsSignInButtonEnabled = true;

        }
    }
}
