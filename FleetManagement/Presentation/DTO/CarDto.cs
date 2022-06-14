using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.DTO
{
    public class CarDto
    {

        public int Id { get;  set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string ChassisNumber { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public FuelType FuelType { get ; set ; }
        public CarType Type { get; set; }
        public PersonDto? Person { get; set; } = null;
        public string Color { get; set; } = string.Empty;
        public int NumberOfDoors { get ; set; }
        public DrivingLicenseType RequiredLicence { get ; set ; }
    }
}
