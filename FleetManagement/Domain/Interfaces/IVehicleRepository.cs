using Domain.Models;

namespace Domain.Interfaces
{
    public interface IVehicleRepository
    {
        Vehicle AddVehicleRepo(Vehicle vehicle);
        void DeleteVehicleRepo(Vehicle vehicle);
        List<Vehicle> GetAllVehicleRepo();
        Vehicle GetVehicleByIdRepo(int id);
        Vehicle UpdateVehicleRepo(Vehicle vehicle);
    }
}