using Domain.Models;
using Domain.Models.Enums;
using Repository.Contexts;

namespace Repository.DBInitializers
{
    public class FuelCardInitializer
    {
        public static readonly List<FuelCard> _fuelCards = new()
        {
            new FuelCard(96694575827745823, new DateOnly(2030, 04, 17), 4444, new List<FuelType> { FuelType.Benzine, FuelType.Diesel }),
            new FuelCard(76194175829245821, new DateOnly(2024, 07, 25), 5423, new List<FuelType> { FuelType.Electric, FuelType.HybridDiesel }),
            new FuelCard(46794775821745828, new DateOnly(2025, 03, 10), 8947, new List<FuelType> { FuelType.HybridDiesel, FuelType.HybridBenzine }),
            new FuelCard(38294475827545826, new DateOnly(2023, 08, 11), 1593, new List<FuelType> { FuelType.Hydrogen, FuelType.Diesel, FuelType.Electric })
        };


        public static void SeedData(Context context)
        {
            context.Database.EnsureCreated();

            foreach(var f in _fuelCards)
            {
                var result = context.FuelCards.Where(b => b.CardNumber == f.CardNumber).FirstOrDefault();
                if(result == null)
                {
                    context.FuelCards.Add(f);
                }

            }

            context.SaveChanges()
;
        }
    }
}
