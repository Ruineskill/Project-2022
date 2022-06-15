#nullable disable
using Domain.Models;
using Domain.Interfaces;
using Repository.Contexts;
using Repository.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    { 
        private readonly Context _context;

        public PersonRepository(Context context) => _context = context;


        public async Task<Person> AddAsync(Person person)
        {
            try
            {
                await _context.Persons.AddAsync(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new PersonRepositoryException(nameof(AddAsync), ex);
            }
            return person;
           
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            try
            {
                return await _context.Persons.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new PersonRepositoryException(nameof(GetAllAsync), ex);
            }
        }

        public async Task<Person> FindAsync(int id)
        {
            try
            {
                return await _context.Persons.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new PersonRepositoryException(nameof(FindAsync), ex);
            }
        }

        public async Task RemoveAsync(Person person)
        {
            try
            {
                if(person.Car != null || person.FuelCard != null)
                {
                    person.Car = null;
                    person.FuelCard = null;
                    await UpdateAsync(person);
                }
                _context.Persons.Remove(person);
                 _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new PersonRepositoryException(nameof(RemoveAsync), ex);
            }
        }

        public async Task UpdateAsync(Person person)
        {
            try
            {
                _context.Persons.Update(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new PersonRepositoryException(nameof(UpdateAsync), ex);
            }
        }

        public IAsyncEnumerable<Person> GetAllStream()
        {
            try
            {

                return _context.Persons.AsNoTracking().AsAsyncEnumerable();
            }
            catch(Exception ex)
            {

                throw new PersonRepositoryException(nameof(GetAllStream), ex);
            }
        }
    }
}
