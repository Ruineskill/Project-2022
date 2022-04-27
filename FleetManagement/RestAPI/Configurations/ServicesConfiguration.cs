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
            services.AddScoped<IUserValidator<IdentityUser>, UserValidator<IdentityUser>>();
            services.AddScoped<IPasswordValidator<IdentityUser>, PasswordValidator<IdentityUser>>();
            services.AddScoped<IPasswordHasher<IdentityUser>, PasswordHasher<IdentityUser>>();
            services.AddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();

    
            services.AddScoped<IdentityErrorDescriber>();
            services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, UserClaimsPrincipalFactory<IdentityUser>>();
            services.AddScoped<UserManager<IdentityUser>>();
            services.AddScoped<RoleManager<IdentityRole>>();
        }
    }
}
