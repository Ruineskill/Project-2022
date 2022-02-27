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
    }
}
