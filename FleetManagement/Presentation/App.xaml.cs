#nullable disable

using Microsoft.Extensions.DependencyInjection;
using Presentation.HttpClients;
using Presentation.Interfaces;
using Presentation.Services;
using Presentation.ViewModels;
using System;
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
            services.AddTransient<IHttpPersonService, HttpPersonService>();
            services.AddTransient<IHttpCarService, HttpCarService>();
            services.AddTransient<IHttpFuelCardService, HttpFuelCardService>();

            // Viewmodels
            services.AddTransient<MainViewModel>();
            services.AddTransient<LogInViewModel>();
            services.AddTransient<FleetViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<CarsViewModel>();



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
