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
        /// <summary>
        /// readonly property
        /// </summary>
        private readonly Context _context;


        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public FuelCardRepository(Context context) => _context = context;

        /// <summary>
        /// Adds a new fuelcard to the db
        /// </summary>
        /// <param name="fuelCard"></param>
        /// <returns>boolean</returns>
        /// <exception cref="FuelCardRepositoryException"></exception>
        public async Task<bool> AddAsync(FuelCard fuelCard)
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

            return true;
        }

        /// <summary>
        /// Removes a new fuelcard from the db
        /// </summary>
        /// <param name="fuelCard"></param>
        /// <returns>boolean</returns>
        /// <exception cref="FuelCardRepositoryException"></exception>
        public bool Remove(FuelCard fuelCard)
        {
            try
            {
                _context.FuelCards.Remove(fuelCard);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new FuelCardRepositoryException(nameof(Remove), ex);
            }

            return true;
        }

        /// <summary>
        /// Get all the fuelcards from the db
        /// </summary>
        /// <param name="car"></param>
        /// <returns>IEnumerable<FuelCard></returns>
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

        /// <summary>
        /// Get a specific fuelcard from the db
        /// </summary>
        /// <param name="car"></param>
        /// <returns>fuelcard</returns>
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

        /// <summary>
        /// Updates a fuelcard from the db
        /// </summary>
        /// <param name="car"></param>
        /// <returns>boolean</returns>
        public async Task<bool> UpdateAsync(FuelCard fuelCard)
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

            return true;
        }

        /// <summary>
        /// Get all the fuelcards from the db without possiblity to alter them
        /// </summary>
        /// <param name="car"></param>
        /// <returns>Enumerable<FuelCard></returns>
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
