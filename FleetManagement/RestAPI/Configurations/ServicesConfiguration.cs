using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Repository.Repositories;
using RestAPI.Authentication;
using RestAPI.Interfaces;
using RestAPI.Services;

namespace RestAPI.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<ICarRepository, CarRepository>();
            services.AddSingleton<IFuelCardRepository, FuelCardRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<ITokenValidationService, TokenValidationService>();
            services.AddScoped<IUserService, UserService>();
           
        }
    }
}
