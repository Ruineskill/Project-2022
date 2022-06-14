#nullable disable warnings

using Microsoft.Extensions.DependencyInjection;
using Presentation.HttpClients;
using Presentation.Interfaces;
using Presentation.Interfaces.ApiHttp;
using Presentation.Interfaces.Listing;
using Presentation.Interfaces.Navigation;
using Presentation.Mediators;
using Presentation.Services;
using Presentation.Services.ApiHttp;
using Presentation.Services.Listing;
using Presentation.Services.Navigation;
using Presentation.ViewModels;
using Presentation.ViewModels.Dialogs;
using Presentation.ViewModels.Listing;
using Presentation.Windows;
using System;
using System.Linq;
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

        public static T? GetService<T>()
        {
           return Current.Services.GetService<T>();
        }

        public static Window ActiveWindow => Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

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
            services.AddScoped<IFleetMediator, FleetMediator>();


            // ViewModels
            services.AddScoped<MainViewModel>();
            services.AddScoped<LogInViewModel>();
            services.AddScoped<FleetViewModel>();
            services.AddScoped<CarListingViewModel>();
            services.AddScoped<PersonListingViewModel>();
            services.AddScoped<FuelCardListingViewModel>();
            services.AddScoped<DetailDialogViewModel>();
            

            // Windows/Dialogs
            services.AddSingleton<MainWindow>();
            services.AddSingleton<IMessageService, MessageService>();
            services.AddSingleton<IDetailService, DetailService>();
            services.AddSingleton<ISelectorService, SelectorService>();

            // Listings
            services.AddSingleton<ICarListingService, CarListingService>();
            services.AddSingleton<IPersonListingService, PersonListingService>();
            services.AddSingleton<IFuelCardListingService, FuelCardListingService>();

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
