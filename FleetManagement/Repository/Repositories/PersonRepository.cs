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
        /// <summary>
        /// readonly property
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public PersonRepository(Context context) => _context = context;

        /// <summary>
        /// Add person to the db
        /// </summary>
        /// <param name="person"></param>
        /// <returns>boolean</returns>
        /// <exception cref="PersonRepositoryException"></exception>
        public async Task<bool> AddAsync(Person person)
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
            return true;
           
        }

        /// <summary>
        /// Get all persons from the db
        /// </summary>
        /// <returns>Enumerable<Person></returns>
        /// <exception cref="PersonRepositoryException"></exception>
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

        /// <summary>
        /// Find one person with specific id in the db
        /// </summary>
        /// <param name="id"></param>
        /// <returns>person</returns>
        /// <exception cref="PersonRepositoryException"></exception>
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

        /// <summary>
        /// Remove one person from the db
        /// </summary>
        /// <param name="person"></param>
        /// <returns>boolean</returns>
        /// <exception cref="PersonRepositoryException"></exception>
        public  bool Remove(Person person)
        {
            try
            {
                _context.Persons.Remove(person);
                 _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new PersonRepositoryException(nameof(Remove), ex);
            }

            return true;
        }

        /// <summary>
        /// Update one person in the db
        /// </summary>
        /// <param name="person"></param>
        /// <returns>boolean</returns>
        /// <exception cref="PersonRepositoryException"></exception>
        public async Task<bool> UpdateAsync(Person person)
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

            return true;
        }

        /// <summary>
        /// Get all persons from the db without possibility to alter them
        /// </summary>
        /// <returns>Enumerable<Person></returns>
        /// <exception cref="PersonRepositoryException"></exception>
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
