using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository
    {
        #region Public

        public User AddVehicle(User user)
        {



            return user;
        }

        public User UpdateVehicle(User user)
        {



            return user;
        }

        public void DeleteVehicle(User user)
        {


        }

        public User GetVehicle(int id)
        {



            return new User { };
        }

        public User GetVehicle(string nationRegistrationNumber)
        {



            return new User { };
        }

        #endregion
    }
}
