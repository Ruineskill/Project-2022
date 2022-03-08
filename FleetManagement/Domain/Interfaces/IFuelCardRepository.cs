using Domain.Models;

namespace Domain.Interfaces
{
    public interface IFuelCardRepository
    {
        FuelCard AddFuelCardRepo(FuelCard fuelCard);
        void DeleteFuelCardRepo(FuelCard fuelCard);
        List<FuelCard> GetAllFuelCardRepo();
        FuelCard GetFuelCardByIdRepo(int id);
        FuelCard UpdateFuelCardRepo(FuelCard fuelCard);
    }
}