using Domain.Interfaces;
using Domain.Services;
using Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICarRepository, CarRepository>();
builder.Services.AddSingleton<IFuelCardRepository, FuelCardRepository>();
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

builder.Services.AddSingleton<CarService>();
builder.Services.AddSingleton<FuelCardService>();
builder.Services.AddSingleton<PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
