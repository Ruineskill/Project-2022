#nullable disable warnings

using Microsoft.Extensions.DependencyInjection;
using Presentation.HttpClients;
using Presentation.Interfaces;
using Presentation.Mediators;
using Presentation.Services;
using Presentation.ViewModels;
using Presentation.Windows;
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

            // Navigation
            services.AddSingleton<INavigationService, MainNavigationService>();
            services.AddSingleton<IDetailNavigationService, DetailNavigationService>();
            services.AddSingleton<IDetailDialogService, DetailDialogService>();
            // Http Api
            services.AddSingleton<IApiSecurityService, ApiSecurityService>();
            services.AddSingleton<HttpClient>();
            services.AddSingleton<ApiHttpClient>();
            services.AddScoped<IHttpPersonService, HttpPersonService>();
            services.AddScoped<IHttpCarService, HttpCarService>();
            services.AddScoped<IHttpFuelCardService, HttpFuelCardService>();

            // Mediators
            services.AddSingleton<CarMediator>();
            services.AddSingleton<FuelCardMediator>();
            services.AddSingleton<PersonMediator>();


            // Viewmodels/windows
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddScoped<LogInViewModel>();
            services.AddScoped<FleetViewModel>();
            services.AddSingleton<CarListingViewModel>();
            services.AddSingleton<PersonListingViewModel>();
            services.AddSingleton<FuelCardListingViewModel>();
            services.AddScoped<DetailViewModel>();
          
            


            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            MainWindow = Services.GetService<MainWindow>();

            MainWindow.DataContext = Services.GetService<MainViewModel>();

            var navigationService = Services.GetRequiredService<INavigationService>();

            navigationService.Navigate(Services.GetService<LogInViewModel>());

            MainWindow.Show();
            base.OnStartup(e);
        }

    }
}
