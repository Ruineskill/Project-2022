using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception for invalid FuelCard expiration date
    /// </summary>
    [Serializable]
    public class InvalidFuelCardExpirationDateException : Exception
    {
        public InvalidFuelCardExpirationDateException() : base() { }
        public InvalidFuelCardExpirationDateException(string message) : base(message) { }
        public InvalidFuelCardExpirationDateException(string message, Exception inner) : base(message, inner) { }
    }
}
