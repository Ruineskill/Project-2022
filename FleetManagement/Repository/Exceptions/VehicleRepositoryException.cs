using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Exceptions
{
    public class VehicleRepositoryException : Exception
    {
        public VehicleRepositoryException(string message) : base(message)
        {
        }

        public VehicleRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
