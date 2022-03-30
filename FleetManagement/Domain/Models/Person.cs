using Domain.Exceptions;
using Domain.Models.Enums;
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
        private DrivingLicenseType _drivingLicenseType;
        private Address? _address;
        private Car? _car;
        private FuelCard? _fuelCard;
        private bool _delete = false;

        public int Id { get => _id; set => _id = value; }
        public string FirstName 
        {
            get => _firstName; 
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(FirstName));
                _firstName = value;
            }
        }
        public string LastName 
        {
            get => _lastName; 
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(LastName));
                _lastName = value;
            }
        }
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
        public DrivingLicenseType DrivingLicenseTypes { get => _drivingLicenseType; set => _drivingLicenseType = value; }
        public Address? Address { get => _address; set => _address = value; }
        public Car? Car { get => _car; set => _car = value; }
        public FuelCard? FuelCard { get => _fuelCard; set => _fuelCard = value; }
        public bool Delete { get => _delete; set => _delete = value; }

        public Person(int id, string firstName, string lastName, DateOnly dateOfBirth, string nationalRegistrationNumber, DrivingLicenseType drivingLicenseType) :
            this(id, firstName, lastName, dateOfBirth, nationalRegistrationNumber, drivingLicenseType, null, null, null)
        { }

        public Person(int id, string firstName, string lastName, DateOnly dateOfBirth, string nationalRegistrationNumber, DrivingLicenseType drivingLicenseType, Address? address, Car? car, FuelCard? fuelCard)
        {
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentNullException(nameof(firstName));
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentNullException(nameof(lastName));
            if (!IsValidDateOfBirth(dateOfBirth)) throw new InvalidDateOfBirthException();
            if (!IsValidNationalRegistrationNumber(nationalRegistrationNumber)) throw new InvalidNationRegistrationNumberException();

            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _nationalRegistrationNumber = nationalRegistrationNumber;
            _drivingLicenseType = drivingLicenseType;
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
