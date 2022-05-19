using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception for invalid license type Requirement
    /// </summary>
    [Serializable]
    public class InvalidLicenseTypeRequirementException : Exception
    {
        public InvalidLicenseTypeRequirementException() : base() { }
        public InvalidLicenseTypeRequirementException(string message) : base(message) { }
        public InvalidLicenseTypeRequirementException(string message, Exception inner) : base(message, inner) { }
    }
}
