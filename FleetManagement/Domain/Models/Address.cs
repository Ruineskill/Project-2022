#nullable disable warnings
using Domain.Exceptions;

namespace Domain.Models
{
    /// <summary>
    /// Models Persons Address
    /// </summary>
    public record Address
    {
        #region Properties
        private string _street;
        private int _number;
        private string _city;
        private int _zipCode;
        #endregion

        #region Getters & Setters
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
            set => _zipCode = IsValidPostalCode(value) ? value : throw new InvalidPostalCodeException();
        } 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="street"></param>
        /// <param name="number"></param>
        /// <param name="city"></param>
        /// <param name="zipCode"></param>
        public Address(string street, int number, string city, int zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            ZipCode = zipCode;
        }

        /// <summary>
        /// Checks if given postal code is valid
        /// </summary>
        /// <param name="code">Postal code</param>
        /// <returns>True if code is valid otherwise False</returns>
        public static bool IsValidPostalCode(int code)
        {
            return code >= 1000 && code <= 9992;
        }

    }
}
