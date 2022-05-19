#nullable disable warnings
using Domain.Exceptions;
using Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    /// <summary>
    /// Models domains Person
    /// </summary>
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

        public int Id { get => _id; private set => _id = value; }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if(string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(FirstName));
                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if(string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(LastName));
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
        public DrivingLicenseType DrivingLicenseType { get => _drivingLicenseType; set => _drivingLicenseType = value; }
        public Address? Address { get => _address; set => _address = value; }

        public Car? Car
        {
            get => _car;
            set
            {
                if(value != null)
                {
                    AssignCar(value);
                }
                else
                {
                    _car = null;
                }
            }
        }

        public FuelCard? FuelCard
        {
            get => _fuelCard;
            set
            {
                if(value != null)
                {
                    AssignFuelCard(value);
                }
                else
                {
                    _fuelCard = null;
                }
            }
        }
        public bool Delete { get => _delete; set => _delete = value; }

        public Person(string firstName, string lastName, DateOnly dateOfBirth, string nationalRegistrationNumber,
            DrivingLicenseType drivingLicenseType)
            : this(0, firstName, lastName, dateOfBirth, nationalRegistrationNumber, drivingLicenseType) { }

        [JsonConstructor]
        public Person(int id, string firstName, string lastName, DateOnly dateOfBirth, string nationalRegistrationNumber, DrivingLicenseType drivingLicenseType)
        {
            _id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalRegistrationNumber = nationalRegistrationNumber;
            DrivingLicenseType = drivingLicenseType;
        }


   
        /// <summary>
        /// Assigns car with validation
        /// </summary>
        /// <param name="car">Car to assign to</param>
        /// <exception cref="InvalidCarException">Throws if car has already a owner </exception>
        /// <exception cref="InvalidLicenseTypeRequirementException"> Throws if person does not have license type to drive the car</exception>
        /// <exception cref="InvalidFuelCardRequirementException">Throws if person has a FuelCard and can't refuel the car</exception>
        private void AssignCar(Car car)
        {
            if(car.Person != null) throw new InvalidCarException("The car is already in use!");
            if(!CanPersonDrive(this, car)) throw new InvalidLicenseTypeRequirementException("Person's car license does not meet the car's required license type");
            if(_fuelCard != null && !FuelCard.CanFuelCardRefuel(_fuelCard, car)) throw new InvalidFuelCardRequirementException("The Person's fuel card does not support the car's fuel type");

            _car = car;
            _car.Person = this;
        }

        /// <summary>
        /// Assigns FuelCard with validation
        /// </summary>
        /// <param name="fuelCard">FuelCard to assign</param>
        /// <exception cref="InvalidFuelCardException">Throws if FuelCard is already in use</exception>
        /// <exception cref="InvalidFuelCardRequirementException">Throws if person has a car and FuelCard can't refuel</exception>
        private void AssignFuelCard(FuelCard fuelCard)
        {
            if(fuelCard.Person != null) throw new InvalidFuelCardException("The fuel card is already in use!");
            if(_car != null && !FuelCard.CanFuelCardRefuel(fuelCard, _car)) throw new InvalidFuelCardRequirementException("Fuel card does not support person's car fuel type!");

            _fuelCard = fuelCard;
            _fuelCard.Person = this;
        }


        /// <summary>
        /// Checks if person has required licensee type to drive car
        /// </summary>
        /// <param name="person">Person to check against</param>
        /// <param name="car">Car to check for</param>
        /// <returns>True if person can drive</returns>
        public static bool CanPersonDrive(Person person, Car car)
        {
            if(car.RequiredLicence <= person._drivingLicenseType)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if is valid Belgium National Registration Number
        /// </summary>
        /// <param name="nrn">National Registration Number</param>
        /// <returns>True if is valid else False</returns>
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

            // we compare the existing checksum with the calculated, again
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

        /// <summary>
        /// Checks if persons Age is at least 18
        /// </summary>
        /// <param name="dateOfBirth">Persons Birth date</param>
        /// <returns>True if person is 18+</returns>
        public static bool IsValidDateOfBirth(DateOnly dateOfBirth)
        {
            return dateOfBirth.Year < DateTime.Now.Year - 18;
        }
    }
}
