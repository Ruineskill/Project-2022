using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Repositories.Fixtures
{
    public class CarFixture
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        private const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CarManager;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static readonly List<Car> _cars = new()
        {
            new Car("BMW", "X", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Diesel, CarType.Jeep),
            new Car("Mercedes", "Class C", "1M8GDM9AXKP042788", "1-234-ABC", FuelType.Electric, CarType.Car),
            new Car("Audi", "A5", "1FBHP26W39G222740", "456-LPO-3", FuelType.Benzine, CarType.Convertible),
            new Car("Porsche ", "Cayenne", "WVWRP61J23W519467", "456-LPD-3", FuelType.Benzine, CarType.Jeep)
        };


        public CarFixture()
        {
            lock(_lock)
            {
                if(!_databaseInitialized)
                {
                    using var context = CreateContext();

                    context.Database.EnsureDeleted();

                    context.Database.EnsureCreated();

                    context.Cars.AddRange(_cars);
                    context.SaveChanges();

                    _databaseInitialized = true;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822")]
        public Context CreateContext()
        {
            return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(ConnectionString).Options);
        }

        public void ResetData()
        {
            using var context = CreateContext();

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            context.Cars.AddRange(_cars);
            context.SaveChanges();
        }
    }
}
