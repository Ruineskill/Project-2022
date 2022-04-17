using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    [Serializable]
    public class InvalidLicenceTypeRequirementException : Exception
    {
        public InvalidLicenceTypeRequirementException() : base() { }
        public InvalidLicenceTypeRequirementException(string message) : base(message) { }
        public InvalidLicenceTypeRequirementException(string message, Exception inner) : base(message, inner) { }
    }
}
