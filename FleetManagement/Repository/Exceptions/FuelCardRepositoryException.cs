using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Exceptions
{
    public class FuelCardRepositoryException : Exception
    {
        public FuelCardRepositoryException(string message) : base(message)
        {
        }

        public FuelCardRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
