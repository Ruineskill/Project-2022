using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Vehicle
    {
        #region Properties
        public int Id { get; protected set; }
        public string ChassisNumber { get; protected set; }
        public string LicensePlate { get; protected set; }
        public string Branch { get; protected set; }
        public string Model { get; protected set; }
        public VehicleType Type { get; protected set; }
        public string Color { get; protected set; }
        public int DoorsCount { get; protected set; }
        public Fuel Fuel { get; protected set; }
        public User? User { get; protected set; }

        #endregion

        #region Constructor
        public Vehicle(int id, string chassisNumber, string licensePlate, string branch, string model, VehicleType type, string color, int doorsCount, Fuel fuel)
        {
            Id = id;
            ChassisNumber = chassisNumber;
            LicensePlate = licensePlate;
            Branch = branch;
            Model = model;
            Type = type;
            Color = color;
            DoorsCount = doorsCount;
            Fuel = fuel;
        }

        public Vehicle(int id, string chassisNumber, string licensePlate, string branch, string model, VehicleType type, string color, int doorsCount)
        {
            Id = id;
            ChassisNumber = chassisNumber;
            LicensePlate = licensePlate;
            Branch = branch;
            Model = model;
            Type = type;
            Color = color;
            DoorsCount = doorsCount;
        }
        #endregion

        public static bool ValidateChassisNumber(string number)
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
