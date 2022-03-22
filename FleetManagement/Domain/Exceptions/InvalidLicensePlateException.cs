using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    [Serializable]
    public class InvalidLicensePlateException : Exception
    {
        public InvalidLicensePlateException() : base() { }
        public InvalidLicensePlateException(string message) : base(message) { }
        public InvalidLicensePlateException(string message, Exception inner) : base(message, inner) { }
    }
}
