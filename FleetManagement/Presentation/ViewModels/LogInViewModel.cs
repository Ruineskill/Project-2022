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
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }

        }


        private SecureString _password = new();

        public SecureString Password
        {
            private get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }

        }



        public LogInViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommand = new RelayCommand(LoginHandler);
        }


        public ICommand LoginCommand { get; }
        public async void LoginHandler()
        {
            var apiService = App.Current.Services.GetService<IApiSecurityService>();


            bool signedIn = await apiService.SignIn(Username, _password);

            if(signedIn)
            {
                       
                _navigationService.Navigate(App.Current.Services.GetService<FleetViewModel>());
            }

          

        }
    }
}
