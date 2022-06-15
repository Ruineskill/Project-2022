#nullable disable warnings
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Exceptions;

namespace Repository.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly Context _context;

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

        public async Task RemoveAsync(Car car)
        {
            try
            {
                if(car.Person != null)
                {
                    car.Person = null;
                    await UpdateAsync(car);
                }
               
                _context.Cars.Remove(car);
                
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new CarRepositoryException(nameof(RemoveAsync), ex);
            }

        }

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

        public async Task UpdateAsync(Car car)
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
