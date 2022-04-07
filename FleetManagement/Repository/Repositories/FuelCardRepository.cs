#nullable disable
using Domain.Models;
using Domain.Interfaces;
using Repository.Contexts;
using Repository.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class FuelCardRepository : IFuelCardRepository
    {
        private readonly Context _ctx = new();

        public async Task<FuelCard> AddAsync(FuelCard fuelCard)
        {
            try
            {
                await _ctx.FuelCards.AddAsync(fuelCard);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new FuelCardRepositoryException(nameof(AddAsync), ex);
            }

            return fuelCard;
        }

        public async void Remove(FuelCard fuelCard)
        {
            try
            {
                _ctx.FuelCards.Remove(fuelCard);
               await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new FuelCardRepositoryException(nameof(Remove), ex);
            }
        }

        public async Task<IEnumerable<FuelCard>> GetAllAsync()
        {
            try
            {
                return await _ctx.FuelCards.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new FuelCardRepositoryException(nameof(GetAllAsync), ex);
            }
        }

        public async Task<FuelCard> FindAsync(int id)
        {
            try
            {
                return await  _ctx.FuelCards.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new FuelCardRepositoryException(nameof(FindAsync), ex);
            }
        }

        public async Task<FuelCard> UpdateAsync(FuelCard fuelCard)
        {
            try
            {
                _ctx.FuelCards.Update(fuelCard);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new FuelCardRepositoryException(nameof(UpdateAsync), ex);
            }

            return fuelCard;
        }
    }
}
