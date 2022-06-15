#nullable disable warnings
using Domain.Models.Enums;
using Presentation.Interfaces.Listing;
using Presentation.ViewModels;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Presentation.Validation
{
    public class CarValidator : ValidatorBase
    {
        private readonly ICarListingService? _cars;

        public CarValidator()
        {
            if(_cars == null) _cars = App.GetService<ICarListingService>();
        }

        public bool Brand(ValidatedViewModelBase context)
        {
            var car = (CarViewModel)context;
            var value = car.Brand;
            if(!IsLetterOnly(value)) return Result(false, "Invalid value");
            return true;
        }
        public bool Model(ValidatedViewModelBase context)
        {

            var car = (CarViewModel)context;
            var value = car.Model;

            if(!IsLetterOrDigit(value)) return Result(false, "Invalid value");


            return true;
        }

        private string? _initialChassis;
        public bool ChassisNumber(ValidatedViewModelBase context)
        {
            var car = (CarViewModel)context;
            var value = car.ChassisNumber;

            if(IsEmptyOrNull(value)) return Result(false, "Required field");

            try
            {
                if(!IsValidChassisNumber(value)) return Result(false, "Invalid Chassis Number");

                if(_initialChassis == null) _initialChassis = value;

            }
            catch(Exception)
            {
                return Result(false, "Invalid Chassis Number");
            }

            if(_initialChassis != value && _cars.ConaintsVinID(value)) return Result(false, "Car already exists with is Number");

            return true;
        }

        private string? _initialLicenseNumber;
        public bool LicensePlate(ValidatedViewModelBase context)
        {
            var car = (CarViewModel)context;
            var value = car.LicensePlate;

            if(IsEmptyOrNull(value)) return Result(false, "Required field");

            try
            {
                if(!IsValidLicensePlate(value)) return Result(false, "Invalid License Plate");
                _initialLicenseNumber = value;
            }
            catch(Exception)
            {

                return Result(false, "Invalid License Plate");
            }

            if(_initialLicenseNumber != value && _cars.ConaintsLicensePlate(value)) return Result(false, "Car already exists with is Plate");

            return true;
        }
        public bool FuelType(ValidatedViewModelBase context)
        {
            var car = (CarViewModel)context;
            var value = car.FuelType;
            var person = car.Person;

            if(person != null && person.FuelCard != null)
            {
                if(!person.FuelCard.UsableFuelTypes.Contains(value)) 
                    ReValidateProperty(nameof(car.Person));
            }


            return true;
        }

        public bool Type(ValidatedViewModelBase context)
        {
            var car = (CarViewModel)context;
            var value = car.Type;
            var person = car.Person;

            if(person != null)
            {
                ReValidateProperty(nameof(car.Person));
            }

            return true;
        }



        public bool Person(ValidatedViewModelBase context)
        {
            var car = (CarViewModel)context;
            var value = car.Person;
     
            if(value != null)
            {
                if(value.DrivingLicenseType < car.RequiredLicence) 
                    return Result(false, "Person can't drive this car");

                if(value.FuelCard != null && !value.FuelCard.UsableFuelTypes.Contains(car.FuelType))
                    return Result(false, "Person's card can't refuel");
            }


            return true;
        }

        public static bool IsValidChassisNumber(string number)
        {
            if(number.Length != 17)
                return false;

            return GetCheckDigit(number) == number[8];
        }

        private static char GetCheckDigit(string number)
        {
            string map = "0123456789X";
            string weights = "8765432X098765432";
            int sum = 0;
            for(int i = 0; i < 17; i++)
            {
                sum += Transliterate(number[i]) * map.IndexOf(weights[i]);
            }
            return map[sum % 11];
        }

        private static int Transliterate(char c)
        {
            return "0123456789.ABCDEFGH..JKLMN.P.R..STUVWXYZ".IndexOf(c) % 10;
        }


        public static bool IsValidLicensePlate(string LicensePlate)
        {
            if(string.IsNullOrEmpty(LicensePlate) || LicensePlate.Length > 9) return false;

            // License plate format are: N-LLL-NNN , N-NNN-LLL, LLL-NNN-N, NNN-LLL-N
            // where N is a digit and L is a letter
            const string pattern = @"[1-9]-[A-Z]{3}-[0-9]{3}|[1-9]-[0-9]{3}-[A-Z]{3}|[A-Z]{3}-[0-9]{3}-[1-9]|[0-9]{3}-[A-Z]{3}-[1-9]";

            return Regex.IsMatch(LicensePlate, pattern);
        }
    }
}
