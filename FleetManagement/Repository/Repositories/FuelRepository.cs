using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class FuelRepository
    {
        #region Public

        public Fuel AddVehicle(Fuel fuel)
        {



            return fuel;
        }

        public Fuel UpdateVehicle(Fuel fuel)
        {



            return fuel;
        }

        public void DeleteVehicle(Fuel fuel)
        {


        }

        public Fuel GetVehicle(int id)
        {



            return new Fuel { };
        }

        public Fuel GetVehicle(string type)
        {



            return new Fuel { };
        }

        #endregion
    }
}
