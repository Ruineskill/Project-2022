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
            services.AddTransient<ITokenGenerator, TokenGenerator>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            services.AddTransient<ITokenValidationService, TokenValidationService>();
            services.AddTransient<IUserService, UserService>();

            // Services used by identity
            services.AddSingleton<IUserValidator<IdentityUser>, UserValidator<IdentityUser>>();
            services.AddSingleton<IPasswordValidator<IdentityUser>, PasswordValidator<IdentityUser>>();
            services.AddSingleton<IPasswordHasher<IdentityUser>, PasswordHasher<IdentityUser>>();
            services.AddSingleton<ILookupNormalizer, UpperInvariantLookupNormalizer>();

    
            services.AddSingleton<IdentityErrorDescriber>();
            services.AddSingleton<IUserClaimsPrincipalFactory<IdentityUser>, UserClaimsPrincipalFactory<IdentityUser>>();
            services.AddSingleton<UserManager<IdentityUser>>();
            services.AddSingleton<RoleManager<IdentityRole>>();
        }
    }
}
