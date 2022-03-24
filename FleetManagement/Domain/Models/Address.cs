using Domain.Exceptions;
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

        public string Street 
        { 
            get => _street; 
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Street));
                _street = value;
            }
        }
        public int StreetNumber { get => _streetNumber; set => _streetNumber = value; }
        public string City 
        { 
            get => _city; 
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(City));
                _city = value;
            }
        }
        public int PostalCode 
        {
            get => _postalCode; 
            set => _postalCode = IsValidPostalCode(value) ? value: throw new InvalidPostalCodeException(); 
        }

        public Address(string street, int streetNumber, string city, int postalCode)
        {
            if(string.IsNullOrEmpty(street)) throw new ArgumentNullException(nameof(street));
            if(string.IsNullOrEmpty(city)) throw new ArgumentNullException(nameof(city));
            if(!IsValidPostalCode(postalCode)) throw new InvalidPostalCodeException();

            _street = street;
            _streetNumber = streetNumber;
            _city = city;
            _postalCode = postalCode;
        }


        public static bool IsValidPostalCode(int code)
        {
            return code >= 1000 && code <= 9992;
        }

    }
}
