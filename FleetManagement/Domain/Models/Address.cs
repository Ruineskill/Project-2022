using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public record Address
    {
        private string _street;
        private int _streetNumber;
        private string _city;
        private int _postalCode;

        public string Street { get => _street; set => _street = value; }
        public int StreetNumber { get => _streetNumber; set => _streetNumber = value; }
        public string City { get => _city; set => _city = value; }
        public int PostalCode { get => _postalCode; set => _postalCode = value; }

        public Address(string street, int streetNumber, string city, int postalCode)
        {
            _street = street;
            _streetNumber = streetNumber;
            _city = city;
            _postalCode = postalCode;
        }


    }
}
