using Domain.Interfaces;
using Repository.Repositories;
using RestAPI.Services;

namespace RestAPI.Configurations
{
    public static  class ServicesConfiguration
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<ICarRepository, CarRepository>();
            services.AddSingleton<IFuelCardRepository, FuelCardRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
