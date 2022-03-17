using Domain.Models;

namespace Domain.Interfaces
{
    public interface IVehicleRepository
    {
        Car AddVehicleRepo(Car vehicle);
        void DeleteVehicleRepo(Car vehicle);
        List<Car> GetAllVehicleRepo();
        Car GetVehicleByIdRepo(int id);
        Car UpdateVehicleRepo(Car vehicle);
    }
}