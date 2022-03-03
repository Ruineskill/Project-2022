using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Exceptions
{
    public class FuelRepositoryException : Exception
    {
        public FuelRepositoryException(string message) : base(message)
        {
        }

        public FuelRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
