using Domain.Exceptions;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Domain.Models
{
    public class Car
    {
        private int _id;
        private string _brand;
        private string _model;
        private string _chassisNumber;
        private string _licensePlate;
        private FuelType _fuelType;
        private CarType _type;
        private Person? _person;
        private string? _color;
        private int _numberOfDoors;

        public int Id { get => _id; set => _id = value; }
        public string Brand
        {
            get => _brand;
            //  set => _brand = string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(nameof(Brand)); does not work
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Brand));
                _brand= value;
            }
        }
        public string Model
        {
            get => _model;
            //set => _model = string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(nameof(Model)); does not work
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Model));
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
        public CarType Type { get => _type; set => _type = value; }
        public Person? Person { get => _person; set => _person = value; }
        public string? Color { get => _color; set => _color = value; }
        public int NumberOfDoors { get => _numberOfDoors; set => _numberOfDoors = value; }


        public Car(int id, string brand, string model, string chassisNumber, string licensePlate, FuelType fuelType, CarType type) :
            this(id, brand, model, chassisNumber, licensePlate, fuelType, type, null, null, 4)
        { }

        public Car(int id, string brand, string model, string chassisNumber, string licensePlate, FuelType fuelType, CarType type, Person? person, string? color, int numberOfDoors)
        {
            if (string.IsNullOrEmpty(brand)) throw new ArgumentNullException(nameof(brand));
            if (string.IsNullOrEmpty(model)) throw new ArgumentNullException(nameof(model));
            if (!IsValidChassisNumber(chassisNumber)) throw new InvalidChassisNumberException();
            if (!IsValidLicensePlate(licensePlate)) throw new InvalidLicensePlateException();

            _id = id;
            _brand = brand;
            _model = model;
            _chassisNumber = chassisNumber;
            _licensePlate = licensePlate;
            _fuelType = fuelType;
            _type = type;
            _person = person;
            _color = color;
            _numberOfDoors = numberOfDoors;
        }


        public static bool IsValidChassisNumber(string number)
        {
            if (number.Length != 17)
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
            for (int i = 0; i < 17; i++)
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
            if (string.IsNullOrEmpty(LicensePlate) || LicensePlate.Length > 9) return false;

            // License plate format are: N-LLL-NNN , N-NNN-LLL, LLL-NNN-N, NNN-LLL-N
            // where N is a digit and L is a letter
            const string pattern = @"[1-9]-[A-Z]{3}-[1-9]{3}|[1-9]-[1-9]{3}-[A-Z]{3}|[A-Z]{3}-[1-9]{3}-[1-9]|[1-9]{3}-[A-Z]{3}-[1-9]";

            return Regex.IsMatch(LicensePlate, pattern);
        }

    }
}
