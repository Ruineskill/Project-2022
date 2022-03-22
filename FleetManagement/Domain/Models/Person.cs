using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Person
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private DateOnly _dateOfBirth;
        private string _nationalRegistrationNumber;
        private ICollection<DrivingLicenseType> _drivingLicenseTypes;
        private Address? _address;
        private Car? _car;
        private FuelCard? _fuelCard;

        public int Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateOnly DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = IsValidDateOfBirth(value) ? value : throw new InvalidDateOfBirthException();
        }
        public string NationalRegistrationNumber
        {
            get => _nationalRegistrationNumber;
            set => _nationalRegistrationNumber = IsValidNationalRegistrationNumber(value) ? value : throw new InvalidNationRegistrationNumberException();
        }
        public ICollection<DrivingLicenseType> DrivingLicenseTypes { get => _drivingLicenseTypes; set => _drivingLicenseTypes = value; }
        public Address? Address { get => _address; set => _address = value; }
        public Car? Car { get => _car; set => _car = value; }
        public FuelCard? FuelCard { get => _fuelCard; set => _fuelCard = value; }

        public Person(int id, string firstName, string lastName, DateOnly dateOfBirth, string nationalRegistrationNumber, ICollection<DrivingLicenseType> drivingLicenseTypes) :
            this(id, firstName, lastName, dateOfBirth, nationalRegistrationNumber, drivingLicenseTypes, null, null, null)
        { }

        public Person(int id, string firstName, string lastName, DateOnly dateOfBirth, string nationalRegistrationNumber, ICollection<DrivingLicenseType> drivingLicenseTypes, Address? address, Car? car, FuelCard? fuelCard)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = IsValidDateOfBirth(dateOfBirth) ? dateOfBirth : throw new InvalidDateOfBirthException();
            _nationalRegistrationNumber = IsValidNationalRegistrationNumber(nationalRegistrationNumber) ? nationalRegistrationNumber : throw new InvalidNationRegistrationNumberException();
            _drivingLicenseTypes = drivingLicenseTypes;
            _address = address;
            _car = car;
            _fuelCard = fuelCard;
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


        public static bool IsValidDateOfBirth(DateOnly dateOfBirth)
        {
            return dateOfBirth.Year < DateTime.Now.Year - 18;
        }
    }
}
