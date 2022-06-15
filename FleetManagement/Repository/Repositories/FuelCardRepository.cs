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
        private readonly Context _context;

        public FuelCardRepository(Context context) => _context = context;

        public async Task<FuelCard> AddAsync(FuelCard fuelCard)
        {
            try
            {
                await _context.FuelCards.AddAsync(fuelCard);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new FuelCardRepositoryException(nameof(AddAsync), ex);
            }

            return fuelCard;
        }

        public async Task RemoveAsync(FuelCard fuelCard)
        {
            try
            {
                if(fuelCard.Person != null)
                {
                    fuelCard.Person = null;
                    await UpdateAsync(fuelCard);
                }

                _context.FuelCards.Remove(fuelCard);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new FuelCardRepositoryException(nameof(RemoveAsync), ex);
            }
        }

        public async Task<IEnumerable<FuelCard>> GetAllAsync()
        {
            try
            {
                return await _context.FuelCards.AsNoTracking().ToListAsync();
            }
            catch(Exception ex)
            {
                throw new FuelCardRepositoryException(nameof(GetAllAsync), ex);
            }
        }

        public async Task<FuelCard> FindAsync(int id)
        {
            try
            {
                return await _context.FuelCards.FindAsync(id);
            }
            catch(Exception ex)
            {
                throw new FuelCardRepositoryException(nameof(FindAsync), ex);
            }
        }

        public async Task UpdateAsync(FuelCard fuelCard)
        {
            try
            {
                _context.FuelCards.Update(fuelCard);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new FuelCardRepositoryException(nameof(UpdateAsync), ex);
            }
        }

        public IAsyncEnumerable<FuelCard> GetAllStream()
        {
            try
            {

                return _context.FuelCards.AsNoTracking().AsAsyncEnumerable();
            }
            catch(Exception ex)
            {

                throw new FuelCardRepositoryException(nameof(GetAllStream), ex);
            }
        }
    }
}
