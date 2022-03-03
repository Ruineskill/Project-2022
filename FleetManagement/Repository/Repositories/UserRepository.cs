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



            return new User(1,"Hendrik","De Wilde","wautersdreef","3B","Melle",9090,new DateOnly(1990,10,04), "90100415338","B");
        }

        public User GetVehicle(string nationRegistrationNumber)
        {



            return new User(1, "Hendrik", "De Wilde", "wautersdreef", "3B", "Melle", 9090, new DateOnly(1990, 10, 04), "90100415338", "B");
        }

        #endregion
    }
}
