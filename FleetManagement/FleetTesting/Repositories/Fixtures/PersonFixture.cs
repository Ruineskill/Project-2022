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

namespace UnitTest.Repositories.Fixtures
{
    public class PersonFixture
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        private const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CarManager;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static readonly List<Person> _persons = new()
        {
            new Person("Luke", "Skywalker", new(1960, 06, 18), "60061812456", DrivingLicenseType.B) { Address = new("Skystreet", 08, "Brussel", 1000) },
            new Person("Boba", "Fett", new(1986, 02, 24), "86022402508", DrivingLicenseType.D) { Address = new("Fettstreet", 322, "Brugge", 8000) },
            new Person("Padmé", "Amidala", new(1981, 05, 03), "81050312962", DrivingLicenseType.B) { Address = new("Amidalastreet", 255, "Mechelen", 2500) },
            new Person("Sheev", "Palpatine", new(1977, 09, 03), "77090381596", DrivingLicenseType.C1E) { Address = new("Palpatinestreet", 12, "Leuven", 3000) },
        };



        public PersonFixture()
        {
            lock(_lock)
            {
                if(!_databaseInitialized)
                {
                    using var context = CreateContext();

                    context.Database.EnsureDeleted();

                    context.Database.EnsureCreated();

                    context.Persons.AddRange(_persons);
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

            context.Persons.AddRange(_persons);
            context.SaveChanges();
        }
    }
}
