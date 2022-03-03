using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class VehicleRepository
    {
        #region Public

        public Vehicle AddVehicle(Vehicle vehicle)
        {



            return vehicle;
        }

        public Vehicle UpdateVehicle(Vehicle vehicle)
        {



            return vehicle;
        }

        public void DeleteVehicle(Vehicle vehicle)
        {


        }

        public Vehicle GetVehicle(int id)
        {



            return new Vehicle(1, "ABC234", "ABC123", "Skoda", "SuperB", Domain.Models.Enums.VehicleType.Car, "red", 5, new Fuel(1, "Benzine"));
        }

        public Vehicle GetVehicle(string licensePlate)
        {



            return new Vehicle(1, "ABC234", "ABC123", "Skoda", "SuperB", Domain.Models.Enums.VehicleType.Car, "red", 5, new Fuel(1, "Benzine"));
        }

        #endregion
    }
}
