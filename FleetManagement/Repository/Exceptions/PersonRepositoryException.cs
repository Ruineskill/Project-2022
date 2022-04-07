using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Exceptions
{
    public class PersonRepositoryException : Exception
    {
        public PersonRepositoryException(string message) : base(message)
        {
        }

        public PersonRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
