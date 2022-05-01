#nullable disable

using Microsoft.Extensions.DependencyInjection;
using Presentation.HttpClients;
using Presentation.Interfaces;
using Presentation.Services;
using Presentation.ViewModels;
using System;
using System.Net.Http;
using System.Windows;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; set; }

        public new static App Current => (App)Application.Current;

        public App()
        {
            Services = ConfigureServices();

        }

        private static IServiceProvider ConfigureServices()
        {

            var services = new ServiceCollection();

            // Services
            services.AddSingleton<INavigationService, MainNavigationService>();
            services.AddSingleton<IApiSecurityService, ApiSecurityService>();
            services.AddSingleton<ApiHttpClient>();
            services.AddSingleton<HttpClient>();
            services.AddTransient<IHttpPersonService, HttpPersonService>();
            services.AddTransient<IHttpCarService, HttpCarService>();
            services.AddTransient<IHttpFuelCardService, HttpFuelCardService>();

            // Viewmodels
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LogInViewModel>();
            services.AddSingleton<FleetViewModel>();
            services.AddSingleton<CarListingViewModel>();
            services.AddSingleton<PersonListingViewModel>();
            services.AddSingleton<FuelCardListingViewModel>();




            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            MainWindow = Services.GetService<MainWindow>();

            MainWindow.DataContext = Services.GetService<MainViewModel>();

            var  navigationService = Services.GetRequiredService<INavigationService>();
            navigationService.Navigate(Services.GetService<LogInViewModel>());

            MainWindow.Show();
            base.OnStartup(e);
        }

    }
}
