#nullable disable warnings
using Domain.Exceptions;
using Domain.Models.Enums;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace Domain.Models
{
    /// <summary>
    /// Models domains Car
    /// </summary>
    public class Car
    {
        private int _id;
        private string _brand;
        private string _model;
        private string _chassisNumber;
        private string _licensePlate;
        private FuelType _fuelType;
        private CarType _type;
        private Person? _person = null;
        private string? _color = null;
        private int _numberOfDoors;
        private bool _isDelete = false;
        private DrivingLicenseType _requiredLicence;

        public int Id { get => _id; private set => _id = value; }
        public string Brand
        {
            get => _brand;
            set
            {
                if(string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Brand));
                _brand = value;
            }
        }
        public string Model
        {
            get => _model;
            set
            {
                if(string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Model));
                _model = value;
            }
        }
        public string ChassisNumber
        {
            get => _chassisNumber;
            set => _chassisNumber = IsValidChassisNumber(value) ? value : throw new InvalidChassisNumberException();
        }
        public string LicensePlate
        {
            get => _licensePlate;
            set => _licensePlate = IsValidLicensePlate(value) ? value : throw new InvalidLicensePlateException();
        }
        public FuelType FuelType { get => _fuelType; set => _fuelType = value; }
        public CarType Type
        {
            get => _type;
            set
            {
                _type = value;
                _requiredLicence = GetLicenceForCarType(value);
            }

        }
        public Person? Person
        {
            get => _person;
            set
            {
                if(value != null)
                {
                    AssignPerson(value); 
                }
                else
                {
                    _person = null;
                }

            }
        }
        public string? Color { get => _color; set => _color = value; }
        public int NumberOfDoors { get => _numberOfDoors; set => _numberOfDoors = value; }
        public bool IsDeleted { get => _isDelete; set => _isDelete = value; }
        public DrivingLicenseType RequiredLicence { get => _requiredLicence; private set => _requiredLicence = value; }

        public Car(string brand, string model, string chassisNumber, string licensePlate,
                   FuelType fuelType, CarType type, string? color = null, int numberOfDoors = 4)
            : this(0, brand, model, chassisNumber, licensePlate, fuelType, type, color, numberOfDoors) { }

        [JsonConstructor]
        public Car(int id, string brand, string model, string chassisNumber, string licensePlate,
                   FuelType fuelType, CarType type, string? color, int numberOfDoors)
        {
            _id = id;
            Brand = brand;
            Model = model;
            ChassisNumber = chassisNumber;
            LicensePlate = licensePlate;
            FuelType = fuelType;
            Type = type;
            Color = color;
            NumberOfDoors = numberOfDoors;
            RequiredLicence = GetLicenceForCarType(_type);
        }



        public static bool IsValidChassisNumber(string number)
        {
            if(number.Length != 17)
                return false;

            return GetCheckDigit(number) == number[8];
        }

        private static char GetCheckDigit(string number)
        {
            //list of the possible check numbers
            string map = "0123456789X";

            //weight of each char of the chassis number
            string weights = "8765432X098765432";
            int sum = 0;
            for(int i = 0; i < 17; i++)
            {
                sum += Transliterate(number[i]) * map.IndexOf(weights[i]);
            }
            return map[sum % 11];
        }

        /// <summary>
        /// translates a letter or number to a specific number (the matrix can be found in the documentation)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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

        public static DrivingLicenseType GetLicenceForCarType(CarType type)
        {
            if(type == CarType.Truck)
            {
                return DrivingLicenseType.C;
            }
            else if(type == CarType.Bus)
            {
                return DrivingLicenseType.D;
            }

            return DrivingLicenseType.B;
        }


        private void AssignPerson(Person person)
        {
            if(_person != null) throw new InvalidCarException("This car belongs to someone else!");
            if(person.Car != this) person.Car = this;
            _person = person;
        }


    }
}
