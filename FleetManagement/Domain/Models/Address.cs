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
        private int _number;
        private string _city;
        private int _zipCode;

        public string Street 
        { 
            get => _street; 
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Street));
                _street = value;
            }
        }
        public int Number { get => _number; set => _number = value; }
        public string City 
        { 
            get => _city; 
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(City));
                _city = value;
            }
        }
        public int ZipCode
        {
            get => _zipCode; 
            set => _zipCode = IsValidPostalCode(value) ? value: throw new InvalidPostalCodeException(); 
        }

        public Address(string street, int number, string city, int zipCode)
        {
            if(string.IsNullOrEmpty(street)) throw new ArgumentNullException(nameof(street));
            if(string.IsNullOrEmpty(city)) throw new ArgumentNullException(nameof(city));
            if(!IsValidPostalCode(zipCode)) throw new InvalidPostalCodeException();

            _street = street;
            _number = number;
            _city = city;
            _zipCode = zipCode;
        }


        public static bool IsValidPostalCode(int code)
        {
            return code >= 1000 && code <= 9992;
        }

    }
}
