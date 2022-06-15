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
    public class PersonValidator : ValidatorBase
    {
        private readonly IPersonListingService? _persons;
        public PersonValidator()
        {
            if(_persons == null) _persons = App.GetService<IPersonListingService>();
        }

        public bool FirstName(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.FirstName;

            if(IsEmptyOrNull(value))
                return Result(false, "Required field");

            if(!IsLetterOnly(value))
                return Result(false, "Only letter are allowed");

            return true;
        }



        public bool LastName(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.LastName;

            if(IsEmptyOrNull(value))
                return Result(false, "Required field");

            if(!IsLetterOnly(value))
                return Result(false, "Only letter are allowed");

            return true;
        }

        public bool DateOfBirth(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.DateOfBirth;


            var birthDay = DateTime.Now.Year - value.Year;

            if(birthDay < 18)
            {
                return Result(false, "Person must be at leas 18 year");
            }

            return true;

        }

        private string? _initialID;
        public bool NationalID(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.NationalID;

            if(IsEmptyOrNull(value)) return Result(false, "Required field");


            try
            {
                if(!IsValidNationalRegistrationNumber(value)) return Result(false, "Invalid number");

                if(_initialID == null) _initialID = value;
            }
            catch(Exception)
            {

                return Result(false, "Invalid number");
            }

            if(_initialID!=value && _persons.ContainsNationalId(value)) return Result(false, "Person with this ID already exists");




            return true;
        }


        public bool DrivingLicenseType(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.DrivingLicenseType;
            if(person.Car != null)
            {
                if(person.Car.RequiredLicence > value)
                    return Result(false, "Does not meet license requirement for car");

                ReValidateProperty(nameof(person.Car));
            }
            return true;

        }
        public bool City(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.City;

            if(!IsLetterOnly(value)) return Result(false, "Invalid City");

            return true;
        }

        public bool Street(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.Street;

            if(!IsLetterOnly(value)) return Result(false, "Invalid Street");

            return true;
        }

        public bool Number(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.Number;

            if(value == 0) return Result(false, "Invalid Number");

            return true;
        }

        public bool ZipCode(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.ZipCode;

            if(value < 1000 || value > 9992) return Result(false, "Invalid zip code");

            return true;
        }

        public bool Car(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.Car;
            var FuelCard = person.FuelCard;
            var LicenseType = person.DrivingLicenseType;

            if(value != null)
            {
                if(FuelCard != null)
                {
                    if(!FuelCard.UsableFuelTypes.Contains(value.FuelType))
                        return Result(false, "Does not support car's fuel type");
                }

                if(value.RequiredLicence > LicenseType)
                    return Result(false, "Does not meet person's license type requirement");

            }
            return true;
        }

        public bool FuelCard(ValidatedViewModelBase context)
        {
            var person = (PersonViewModel)context;
            var value = person.FuelCard;
            var Car = person.Car;


            if(value != null && Car != null)
            {
                if(!value.UsableFuelTypes.Contains(Car.FuelType))
                {
                    return Result(false, "Fuel card not support");
                }

            }
            return true;
        }




        public static bool IsValidNationalRegistrationNumber(string nrn)
        {
            //Last 2 digits of NationRegistration Number
            var nrnChecksum = Convert.ToInt64(nrn.Substring(9, 2));

            //First 9 digits to calculate
            var partToCalculate = nrn.Substring(0, 9);

            //Calculation
            var checksum = 97 - (Convert.ToInt64(partToCalculate) % 97);

            //Compare if equals return true
            if(nrnChecksum == checksum) return true;

            //// Checksum not yet ok. We check for a possible 1900/2000 situation;

            // we repeat the same test but now with the extra '2' added to the part
            partToCalculate = "2" + partToCalculate;

            // we calculate the expected checksum. again
            checksum = 97 - (Convert.ToInt64(partToCalculate) % 97);

            // we compare the excisting checksum with the calculated, again
            if(nrnChecksum == checksum)
            {
                // we have a good checksum. Person born between 2000 and now
                return true;
            }
            else
            {
                // invalid number, even after 2000 check
                return false;
            }
        }
    }
}
