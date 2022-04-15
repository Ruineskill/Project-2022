#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Repository.Contexts;
using Repository.DBInitializers;
using RestAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "RestAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});



// Database
DatabaseConfiguration.ConfigureDB(builder);

// Authentication
SecurityConfiguration.ConfigureAuthentication(builder);

// Authorization
SecurityConfiguration.ConfigureAuthorization(builder);

// Repositories
ServicesConfiguration.ConfigureRepositories(builder.Services);

// Services
ServicesConfiguration.ConfigureServices(builder.Services);



var app = builder.Build();

// data seed
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetService<UserManager<IdentityUser>>();
    var roleManager = services.GetService<RoleManager<IdentityRole>>();
    UserInitializer.SeedData(userManager, roleManager);

    using var context = services.GetService<Context>();
    CarInitializer.SeedData(context);
    FuelCardInitializer.SeedData(context);
    PersonInitializer.SeedData(context);

}



// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();