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
        #region Properties
        public int Id { get; protected set; }
        public string ChassisNumber { get; protected set; }
        public string LicensePlate { get; protected set; }
        public string Brand { get; protected set; }
        public string Model { get; protected set; }
        public CarType Type { get; protected set; }
        public string Color { get; protected set; }
        public int DoorCount { get; protected set; }
        public Fuel Fuel { get; protected set; }
        public User? User { get; protected set; }

        #endregion

        #region Constructor
        public Car(int id, string chassisNumber, string licensePlate, string brand, string model, Fuel fuel , CarType type,  string color = "Unknown", int doorCount = 2)
        {
            if (!IsValidChassisNumber(chassisNumber)) 
                throw new InvalidChassisNumberException("Vehicle chassis number is not valid!", chassisNumber);

            if (!IsValidLicensePlate(licensePlate))
                throw new InvalidLicensePlateException("Vehicle license plate is not valid!", licensePlate);

            if (string.IsNullOrEmpty(brand))
                throw new ArgumentNullException(nameof(brand));

            if (string.IsNullOrEmpty(model))
                throw new ArgumentNullException(nameof(model));

            Id = id;
            ChassisNumber = chassisNumber;
            LicensePlate = licensePlate;
            Brand = brand;
            Model = model;
            Type = type;
            Color = color;
            DoorCount = doorCount;
            Fuel = fuel;
        }

        public void AssignUser(User user)
        {
            User = user;   
        }

        #endregion

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
