using Domain.Models;

namespace Domain.Interfaces
{
    public interface IFuelRepository
    {
        Fuel AddFuelRepo(Fuel fuel);
        void DeleteFuelRepo(Fuel fuel);
        List<Fuel> GetAllFuelRepo();
        Fuel GetFuelByIdRepo(int id);
        Fuel UpdateFuelRepo(Fuel fuel);
    }
}