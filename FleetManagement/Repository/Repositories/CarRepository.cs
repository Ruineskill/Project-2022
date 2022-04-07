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
        private readonly Context _ctx = new();

        public async Task<Car> AddAsync(Car car)
        {
            try
            {
                await _ctx.Cars.AddAsync(car);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CarRepositoryException(nameof(AddAsync), ex);
            }

            return car;
        }

        public async void Remove(Car car)
        {
            try
            {
                _ctx.Cars.Remove(car);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CarRepositoryException(nameof(Remove), ex);
            }
        }   

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            try
            {
                return await _ctx.Cars.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new CarRepositoryException(nameof(GetAllAsync), ex);
            }
        }

        public async Task<Car> FindAsync(int id)
        {
            try
            {
                return await _ctx.Cars.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new CarRepositoryException(nameof(FindAsync), ex);
            }
        }

        public async Task<Car> UpdateAsync(Car car)
        {
            try
            {
                _ctx.Cars.Update(car);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CarRepositoryException(nameof(UpdateAsync), ex);
            }

            return car;
        }
    }
}
