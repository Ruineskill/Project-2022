using Domain.Models;
using Domain.Interfaces;
using Repository.Contexts;
using Repository.Exceptions;

namespace Repository.Repositories
{
    public class FuelCardRepository : IFuelCardRepository
    {
        private Context ctx = new Context();

        #region Public
        public FuelCard AddFuelCardRepo(FuelCard fuelCard)
        {
            try
            {
                ctx.FuelCard.Add(fuelCard);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelCardRepositoryException(nameof(AddFuelCardRepo), ex);
            }

            return fuelCard;
        }

        public FuelCard UpdateFuelCardRepo(FuelCard fuelCard)
        {
            try
            {
                var tempFuelCard = ctx.FuelCard.Find(fuelCard.Id);
                tempFuelCard.CardNumber = fuelCard.CardNumber;
                tempFuelCard.PinCode = fuelCard.PinCode;
                tempFuelCard.User = fuelCard.User;
                tempFuelCard.Fuels = fuelCard.Fuels;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelCardRepositoryException(nameof(UpdateFuelCardRepo), ex);
            }

            return fuelCard;
        }

        public void DeleteFuelCardRepo(FuelCard fuelCard)
        {
            try
            {
                ctx.FuelCard.Remove(fuelCard);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelCardRepositoryException(nameof(DeleteFuelCardRepo), ex);
            }
        }

        public FuelCard GetFuelCardByIdRepo(int id)
        {
            try
            {
                return ctx.FuelCard.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelCardRepositoryException(nameof(GetFuelCardByIdRepo), ex);
            }
        }

        public List<FuelCard> GetAllFuelCardRepo()
        {
            try
            {
                return ctx.FuelCard.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelCardRepositoryException(nameof(GetAllFuelCardRepo), ex);
            }
        }

        #endregion
    }
}
