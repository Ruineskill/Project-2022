using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    [Serializable]
    public class InvalidFuelCardRequirementException : Exception
    {
        public InvalidFuelCardRequirementException() : base() { }
        public InvalidFuelCardRequirementException(string message) : base(message) { }
        public InvalidFuelCardRequirementException(string message, Exception inner) : base(message, inner) { }
    }
}
