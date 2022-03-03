using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class FuelCardRepository
    {
        #region Public

        public FuelCard AddVehicle(FuelCard fuelCard)
        {



            return fuelCard;
        }

        public FuelCard UpdateVehicle(FuelCard fuelCard)
        {



            return fuelCard;
        }

        public void DeleteVehicle(FuelCard vehicle)
        {


        }

        public FuelCard GetVehicle(int id)
        {



            return new FuelCard { };
        }

        public FuelCard GetVehicle(string cardNumber)
        {



            return new FuelCard { };
        }

        #endregion
    }
}
