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
    public class FuelCardFixture
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        private const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=FleetManager;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static readonly List<FuelCard> _fuelCards = new()
        {
            new FuelCard(96694575827745823, new DateOnly(2030, 04, 17), 4444, new List<FuelType> { FuelType.Benzine, FuelType.Diesel }),
            new FuelCard(76194175829245821, new DateOnly(2024, 07, 25), 5423, new List<FuelType> { FuelType.Electric, FuelType.HybridDiesel }),
            new FuelCard(46794775821745828, new DateOnly(2025, 03, 10), 8947, new List<FuelType> { FuelType.HybridDiesel, FuelType.HybridBenzine }),
            new FuelCard(38294475827545826, new DateOnly(2023, 08, 11), 1593, new List<FuelType> { FuelType.Hydrogen, FuelType.Diesel, FuelType.Electric })
        };


        public FuelCardFixture()
        {
            lock(_lock)
            {
                if(!_databaseInitialized)
                {
                    using var context = CreateContext();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    context.FuelCards.AddRange(_fuelCards);
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

            context.FuelCards.AddRange(_fuelCards);
            context.SaveChanges();
        }
    }
}
