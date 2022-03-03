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
    }
}
