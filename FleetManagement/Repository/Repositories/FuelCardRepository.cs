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
                ctx.FuelCards.Add(fuelCard);
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
                var tempFuelCard = ctx.FuelCards.Find(fuelCard.Id);
                tempFuelCard.CardNumber = fuelCard.CardNumber;
                tempFuelCard.PinCode = fuelCard.PinCode;
                tempFuelCard.ExpirationDate  = fuelCard.ExpirationDate;
                tempFuelCard.Person = fuelCard.Person;
                tempFuelCard.UsableFuelTypes = fuelCard.UsableFuelTypes;
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
                ctx.FuelCards.Remove(fuelCard);
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
                return ctx.FuelCards.Find(id);
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
                return ctx.FuelCards.ToList();
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
