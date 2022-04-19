using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using RestAPI.Authentication.AuthorizationHandlers;
using RestAPI.Authentication.AuthorizationRequirement;
using RestAPI.Authentication.Constants;
using System.Text;

namespace RestAPI.Configurations
{
    public static class SecurityConfiguration
    {
        public static void ConfigureAuthentication(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = builder.Configuration["AuthSettings:Audience"],
                    ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:Key"])),
                    SaveSigninToken = true,
                   

                };
            });
        }

        public static void ConfigureAuthorization(WebApplicationBuilder builder)
        {
            // add Requirements
            builder.Services.AddAuthorization(options =>
            {

                options.AddPolicy(UserPolicies.Admin, policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new AdminRequirement());
                });

                options.AddPolicy(UserPolicies.Manager, policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new ManagerRequirement());
                });

                options.AddPolicy(UserPolicies.User, policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new UserRequirement());
                });

                options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });


            // register handlers
            builder.Services.AddSingleton<IAuthorizationHandler, AdminHandler>();
            builder.Services.AddSingleton<IAuthorizationHandler, ManagerHandler>();
            builder.Services.AddSingleton<IAuthorizationHandler, UserHandler>();
        }
    }
}
