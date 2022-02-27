using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public DateOnly DayOfBirth { get; set; }
        public int NationRegistrationNumber { get; set; }
        public string DriversLicenseType { get; set; }
        public Vehicle? Vehicle { get; set; }
        public FuelCard? FuelCard { get; set; }

        #endregion
    }
}
