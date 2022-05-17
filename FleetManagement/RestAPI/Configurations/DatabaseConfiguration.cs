using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;

namespace RestAPI.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDB(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("RestAPIConnection");
            builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString),
                                                   ServiceLifetime.Transient, ServiceLifetime.Singleton);

            var authConnectionString = builder.Configuration.GetConnectionString("AuthRestAPIConnection");
            builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(authConnectionString));

            builder.Services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AuthContext>().AddDefaultTokenProviders();

            
        }
    }
}
