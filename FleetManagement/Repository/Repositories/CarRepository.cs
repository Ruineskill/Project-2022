using Domain.Models;
using Domain.Interfaces;
using Repository.Contexts;
using Repository.Exceptions;

namespace Repository.Repositories
{
    public class CarRepository : ICarRepository
    {
        private Context ctx = new Context();

        #region Public
        public Car AddCarRepo(Car vehicle)
        {
            try
            {
                ctx.Cars.Add(vehicle);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new VehicleRepositoryException(nameof(AddCarRepo), ex);
            }

            return vehicle;
        }

        public Car UpdateCarRepo(Car vehicle)
        {
            try
            {
                var tempVehicle = ctx.Cars.Find(vehicle.Id);
                tempVehicle.ChassisNumber = vehicle.ChassisNumber;
                tempVehicle.LicensePlate = vehicle.LicensePlate;
                tempVehicle.Brand = vehicle.Brand;
                tempVehicle.Model = vehicle.Model;
                tempVehicle.Type = vehicle.Type;
                tempVehicle.Color = vehicle.Color;
                tempVehicle.DoorCount = vehicle.DoorCount;
                tempVehicle.Fuel = vehicle.Fuel;
                tempVehicle.User = vehicle.User;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new VehicleRepositoryException(nameof(UpdateCarRepo), ex);
            }

            return vehicle;
        }

        public void DeleteCarRepo(Car vehicle)
        {
            try
            {
                ctx.Cars.Remove(vehicle);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new VehicleRepositoryException(nameof(DeleteCarRepo), ex);
            }
        }

        public Car GetCarByIdRepo(int id)
        {
            try
            {
                return ctx.Cars.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new VehicleRepositoryException(nameof(GetCarByIdRepo), ex);
            }
        }

        public List<Car> GetAllCarRepo()
        {
            try
            {
                return ctx.Cars.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new VehicleRepositoryException(nameof(GetAllCarRepo), ex);
            }
        }

        #endregion
    }
}
