using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception for invalid  national registration number
    /// </summary>
    [Serializable]
    public class InvalidNationRegistrationNumberException: Exception
    {
        public InvalidNationRegistrationNumberException() : base() { }
        public InvalidNationRegistrationNumberException(string message) : base(message) { }
        public InvalidNationRegistrationNumberException(string message, Exception inner) : base(message, inner) { }

       
    }
}
