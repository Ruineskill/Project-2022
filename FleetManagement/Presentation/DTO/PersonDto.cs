using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.DTO
{
    public class PersonDto
    {
        public int Id { get;  set; }
        public string FirstName{get;set; } = string.Empty;
        public string LastName{ get ;set; } = string.Empty;
        public DateOnly DateOfBirth {get ;set ; }
        public string NationalRegistrationNumber {get ;set ; } = string.Empty;
        public DrivingLicenseType DrivingLicenseType { get ; set ; }
        public AddressDto? Address { get; set; }

        public CarDto? Car{get;set;}

        public FuelCardDto? FuelCard { get; set; }
    }
}
