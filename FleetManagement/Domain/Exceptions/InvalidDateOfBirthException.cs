using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception for invalid DateOfBirth
    /// </summary>
    [Serializable]
    public class InvalidDateOfBirthException : Exception
    {
        public InvalidDateOfBirthException() : base() { }
        public InvalidDateOfBirthException(string message) : base(message) { }
        public InvalidDateOfBirthException(string message, Exception inner) : base(message, inner) { }
    }
}
