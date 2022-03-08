using Domain.Models;
using Domain.Interfaces;
using Repository.Contexts;
using Repository.Exceptions;

namespace Repository.Repositories
{
    public class FuelRepository : IFuelRepository
    {
        private Context ctx = new Context();

        #region Public
        public Fuel AddFuelRepo(Fuel fuel)
        {
            try
            {
                ctx.Fuel.Add(fuel);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelRepositoryException(nameof(AddFuelRepo), ex);
            }

            return fuel;
        }

        public Fuel UpdateFuelRepo(Fuel fuel)
        {
            try
            {
                var tempFuel = ctx.Fuel.Find(fuel.Id);
                tempFuel.Type = fuel.Type;
                tempFuel.FuelCards = fuel.FuelCards;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelRepositoryException(nameof(UpdateFuelRepo), ex);
            }

            return fuel;
        }

        public void DeleteFuelRepo(Fuel fuel)
        {
            try
            {
                ctx.Fuel.Remove(fuel);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelRepositoryException(nameof(DeleteFuelRepo), ex);
            }
        }

        public Fuel GetFuelByIdRepo(int id)
        {
            try
            {
                return ctx.Fuel.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelRepositoryException(nameof(GetFuelByIdRepo), ex);
            }
        }

        public List<Fuel> GetAllFuelRepo()
        {
            try
            {
                return ctx.Fuel.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelRepositoryException(nameof(GetAllFuelRepo), ex);
            }
        }

        #endregion
    }
}
