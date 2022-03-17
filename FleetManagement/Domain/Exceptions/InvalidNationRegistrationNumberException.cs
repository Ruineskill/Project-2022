using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidNationRegistrationNumberException: Exception
    {
        public string NationRegistrationNumber { get; }

        public InvalidNationRegistrationNumberException() : base() { }
        public InvalidNationRegistrationNumberException(string message) : base(message) { }
        public InvalidNationRegistrationNumberException(string message, Exception inner) : base(message, inner) { }

        public InvalidNationRegistrationNumberException(string message, string NationRegistrationNumber) : base(message) 
        {
            this.NationRegistrationNumber = NationRegistrationNumber;
        }
    }
}
