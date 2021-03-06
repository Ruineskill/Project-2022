using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception for invalid postal code
    /// </summary>
    [Serializable]
    public class InvalidPostalCodeException : Exception
    {
        public InvalidPostalCodeException() : base() { }
        public InvalidPostalCodeException(string message) : base(message) { }
        public InvalidPostalCodeException(string message, Exception inner) : base(message, inner) { }


    }
}
