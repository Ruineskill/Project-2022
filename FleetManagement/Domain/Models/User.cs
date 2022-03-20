using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        #region Properties
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string FirstName { get;  set; }
        public string Street { get;  set; }
        public string HouseNumber { get;  set; }
        public string City { get;  set; }
        public int PostalCode { get;  set; }
        public DateOnly DayOfBirth { get;  set; }
        public string NationRegistrationNumber { get;  set; }
        public string DriversLicenseType { get;  set; }
        public Car? Vehicle { get;  set; }
        public FuelCard? FuelCard { get;  set; }

        #endregion

        #region Constructor
        public User(int id, string name, string firstName, string street, string houseNumber, string city, int postalCode, DateOnly dayOfBirth, string nationRegistrationNumber, string driversLicenseType, Car? vehicle, FuelCard? fuelCard)
        {
            Id = id;
            Name = name;
            FirstName = firstName;
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            PostalCode = postalCode;
            DayOfBirth = dayOfBirth;
            NationRegistrationNumber = nationRegistrationNumber;
            DriversLicenseType = driversLicenseType;
            Vehicle = vehicle;
            FuelCard = fuelCard;
        }
        public User(int id, string name, string firstName, string street, string houseNumber, string city, int postalCode, DateOnly dayOfBirth, string nationRegistrationNumber, string driversLicenseType)
        {
            Id = id;
            Name = name;
            FirstName = firstName;
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            PostalCode = postalCode;
            DayOfBirth = dayOfBirth;
            NationRegistrationNumber = nationRegistrationNumber;
            DriversLicenseType = driversLicenseType;
        }

        #endregion

        #region Public
        public static bool IsValidNationalRegistrationNumber(string nrn)
        {
            //Last 2 digits of NationRegistration Number
            var nrnChecksum = Convert.ToInt64(nrn.Substring(9, 2));

            //First 9 digits to calculate
            var partToCalculate = nrn.Substring(0, 9);

            //Calculation
            var checksum = 97 - (Convert.ToInt64(partToCalculate) % 97);

            //Compare if equals return true
            if (nrnChecksum == checksum) return true;

            //// Checksum not yet ok. We check for a possible 1900/2000 situation;

            // we repeat the same test but now with the extra '2' added to the part
            partToCalculate = "2" + partToCalculate;

            // we calculate the expected checksum. again
            checksum = 97 - (Convert.ToInt64(partToCalculate) % 97);

            // we compare the excisting checksum with the calculated, again
            if (nrnChecksum == checksum)
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
        #endregion
    }
}
