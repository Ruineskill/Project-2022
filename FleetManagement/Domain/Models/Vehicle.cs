using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Vehicle
    {
        #region Properties
        public int Id { get; set; }
        public string ChassisNumber { get; set; }
        public string LicensePlate { get; set; }
        public string Branch { get; set; }
        public string Model { get; set; }
        public VehicleType Type { get; set; }
        public string Color { get; set; }
        public int DoorsCount { get; set; }
        public Fuel Fuel { get; set; }
        public User? User { get; set; }

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
        #region Public
        public static bool validateChassisNumber(string number)
        {
            if (number.Length != 17)
                return false;

            return getCheckDigit(number) == number[8];
        }

        private static char getCheckDigit(string number)
        {
            //list of the possible check numbers
            string map = "0123456789X";

            //weigh of each char of the chassis number
            string weights = "8765432X098765432";
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += transliterate(number[i]) * map.IndexOf(weights[i]);
            }
            return map[sum % 11];
        }
        /// <summary>
        /// translates a letter or number to a specific number (the matrix can be found in the documentation)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static int transliterate(char c)
        {
            return "0123456789.ABCDEFGH..JKLMN.P.R..STUVWXYZ".IndexOf(c) % 10;
        }
        #endregion
    }
}
