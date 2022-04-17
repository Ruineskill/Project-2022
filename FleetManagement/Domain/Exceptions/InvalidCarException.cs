using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    [Serializable]
    public class InvalidCarException : Exception
    {
        public InvalidCarException() : base() { }
        public InvalidCarException(string message) : base(message) { }
        public InvalidCarException(string message, Exception inner) : base(message, inner) { }
    }
}
