#nullable disable
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Exceptions;

namespace Repository.Repositories
{
    public class CarRepository : ICarRepository
    {
        /// <summary>
        /// readonly property
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public CarRepository(Context context) => _context = context;

        public async Task<Car> AddAsync(Car car)
        {
            try
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new CarRepositoryException(nameof(AddAsync), ex);
            }
            return car;
        }

        public bool Remove(Car car)
        {
            try
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new CarRepositoryException(nameof(Remove), ex);
            }

        }

        /// <summary>
        /// Get all the cars from the db
        /// </summary>
        /// <returns>Enumerable<Car></returns>
        /// <exception cref="CarRepositoryException"></exception>
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            try
            {
                return await _context.Cars.AsNoTracking().ToListAsync();
            }
            catch(Exception ex)
            {
                throw new CarRepositoryException(nameof(GetAllAsync), ex);
            }
        }

        /// <summary>
        /// Find a car by id in the db
        /// </summary>
        /// <param name="id"></param>
        /// <returns>car</returns>
        /// <exception cref="CarRepositoryException"></exception>
        public async Task<Car> FindAsync(int id)
        {
            try
            {
                return await _context.Cars.FindAsync(id);
            }
            catch(Exception ex)
            {
                throw new CarRepositoryException(nameof(FindAsync), ex);
            }
        }

        public async Task<bool> UpdateAsync(Car car)
        {
            try
            {
                _context.Cars.Update(car);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new CarRepositoryException(nameof(UpdateAsync), ex);
            }


        }

        /// <summary>
        /// Get all cars from the db without possibility to alter them
        /// </summary>
        /// <returns>Enumerable<Car></returns>
        /// <exception cref="CarRepositoryException"></exception>
        public IAsyncEnumerable<Car> GetAllStream()
        {
            try
            {
                return _context.Cars.AsNoTracking().AsAsyncEnumerable();
            }
            catch(Exception ex)
            {

                throw new CarRepositoryException(nameof(GetAllStream), ex);
            }
        }
    }
}
