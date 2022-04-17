using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DBInitializers
{
    public class CarInitializer
    {
        public static readonly List<Car> _cars = new()
        {
            new Car("BMW", "X", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Diesel, CarType.Jeep),
            new Car("Mercedes", "Class C", "1M8GDM9AXKP042788", "1-234-ABC", FuelType.Electric, CarType.Car),
            new Car("Audi", "A5", "1FBHP26W39G222740", "456-LPO-3", FuelType.Benzine, CarType.Convertible),
            new Car("Porsche ", "Cayenne", "WVWRP61J23W519467", "456-LPD-3", FuelType.Benzine, CarType.Jeep)
        };

        public static void SeedData(Contexts.Context context)
        {
            context.Database.EnsureCreated();

            foreach(var c in _cars)
            {
                var result = context.Cars.Where(b => b.ChassisNumber == c.ChassisNumber && b.LicensePlate == c.LicensePlate).FirstOrDefault();
                if(result == null)
                {
                    context.Cars.Add(c);
                }

            }
            context.SaveChanges();

        }
    }
}
