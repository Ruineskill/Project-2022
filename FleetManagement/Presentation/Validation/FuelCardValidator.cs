#nullable disable warnings
using Presentation.Interfaces.Listing;
using Presentation.ViewModels;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Validation
{
    public class FuelCardValidator : ValidatorBase
    {
        private readonly IFuelCardListingService? _fuelCards;
        public FuelCardValidator()
        {
            if(_fuelCards == null) _fuelCards = App.GetService<IFuelCardListingService>();
        }


        private long? _initialNumber;
        public bool CardNumber(ValidatedViewModelBase context)
        {
            var fuelCard = (FuelCardViewModel)context;
            var value = fuelCard.CardNumber;

            if(value.ToString().Length < 10) return Result(false, "Card number must be at least 10 digits");

            if(_initialNumber == null) _initialNumber = value;

            if(_initialNumber != value && _fuelCards.ContainsCardNumber(value)) return Result(false, "Card number already exists");

            return true;
        }

        public bool ExpirationDate(ValidatedViewModelBase context)
        {
            var fuelCard = (FuelCardViewModel)context;
            var value = fuelCard.ExpirationDate;

            var now = DateOnly.FromDateTime(DateTime.Now);

            if(now > value)
            {
                return Result(false, "Already expired!");
            }


            return true;
        }

        public bool PinCode(ValidatedViewModelBase context)
        {
            var fuelCard = (FuelCardViewModel)context;
            var value = fuelCard.PinCode;

            if(!IsNumericOnly(value.ToString())) return Result(false, "Invalid code");

            if(value.ToString().Length != 4) return Result(false, "Pin code must be 4 digits");

            return true;
        }
           
    
        public bool UsableFuelTypes(ValidatedViewModelBase context)
        {
            var fuelCard = (FuelCardViewModel)context;
            var value = fuelCard.UsableFuelTypes;

            if(!value.Any()) return Result(false, "At leas one fuel must be supported");
            if(fuelCard.Person != null) ReValidateProperty(nameof(fuelCard.Person));

            return true;
        }

        public bool Person(ValidatedViewModelBase context)
        {
            var fuelCard = (FuelCardViewModel)context;
            var value = fuelCard.Person;

            if(value!= null)
            {
                if(value.Car != null && !fuelCard.UsableFuelTypes.Contains(value.Car.FuelType))
                    return Result(false, "This card can't refuel persons car");
            }

            return true;
        }
    }
}
