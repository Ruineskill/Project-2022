using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception for invalid FuelCard
    /// </summary>
    [Serializable]
    public class InvalidFuelCardException:Exception
    {
        public InvalidFuelCardException() : base() { }
        public InvalidFuelCardException(string message) : base(message) { }
        public InvalidFuelCardException(string message, Exception inner) : base(message, inner) { }
    }
}
