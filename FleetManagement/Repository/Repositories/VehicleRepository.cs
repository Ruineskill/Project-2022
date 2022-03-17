using Domain.Models;
using Domain.Interfaces;
using Repository.Contexts;
using Repository.Exceptions;

namespace Repository.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private Context ctx = new Context();

        #region Public
        public Vehicle AddVehicleRepo(Vehicle vehicle)
        {
            try
            {
                ctx.Vehicle.Add(vehicle);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new VehicleRepositoryException(nameof(AddVehicleRepo), ex);
            }

            return vehicle;
        }

        public Vehicle UpdateVehicleRepo(Vehicle vehicle)
        {
            try
            {
                var tempVehicle = ctx.Vehicle.Find(vehicle.Id);
                tempVehicle.ChassisNumber = vehicle.ChassisNumber;
                tempVehicle.LicensePlate = vehicle.LicensePlate;
                tempVehicle.Branch = vehicle.Branch;
                tempVehicle.Model = vehicle.Model;
                tempVehicle.Type = vehicle.Type;
                tempVehicle.Color = vehicle.Color;
                tempVehicle.DoorsCount = vehicle.DoorCount;
                tempVehicle.Fuel = vehicle.Fuel;
                tempVehicle.User = vehicle.User;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new VehicleRepositoryException(nameof(UpdateVehicleRepo), ex);
            }

            return vehicle;
        }

        public void DeleteVehicleRepo(Vehicle vehicle)
        {
            try
            {
                ctx.Vehicle.Remove(vehicle);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new VehicleRepositoryException(nameof(DeleteVehicleRepo), ex);
            }
        }

        public Vehicle GetVehicleByIdRepo(int id)
        {
            try
            {
                return ctx.Vehicle.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new VehicleRepositoryException(nameof(GetVehicleByIdRepo), ex);
            }
        }

        public List<Vehicle> GetAllVehicleRepo()
        {
            try
            {
                return ctx.Vehicle.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new VehicleRepositoryException(nameof(GetAllVehicleRepo), ex);
            }
        }

        #endregion
    }
}
