using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DBInitializers
{
    public class PersonInitializer
    {
        public static readonly List<Person> _persons = new()
        {
            new Person("Luke", "Skywalker", new(1960, 06, 18), "60061812456", DrivingLicenseType.B) { Address = new("Skystreet", 08, "Brussel", 1000) },
            new Person("Boba", "Fett", new(1986, 02, 24), "86022402508", DrivingLicenseType.D) { Address = new("Fettstreet", 322, "Brugge", 8000) },
            new Person("Padmé", "Amidala", new(1981, 05, 03), "81050312962", DrivingLicenseType.B) { Address = new("Amidalastreet", 255, "Mechelen", 2500) },
            new Person("Sheev", "Palpatine", new(1977, 09, 03), "77090381596", DrivingLicenseType.C1E) { Address = new("Palpatinestreet", 12, "Leuven", 3000) },
        };
        public static void SeedData(Contexts.Context context)
        {
            context.Database.EnsureCreated();

            foreach(var p in _persons)
            {
               var result= context.Persons.Where(b=>b.FirstName == p.FirstName &&
                                                    b.LastName == p.LastName && 
                                                    b.NationalRegistrationNumber == p.NationalRegistrationNumber).FirstOrDefault();
                if(result ==null)
                {
                    context.Persons.Add(p);
                }

            }

            context.SaveChanges();
        }
    }
}
