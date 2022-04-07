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
        private readonly Context _ctx = new();

        public async Task<Person> AddAsync(Person person)
        {
            try
            {
                await _ctx.Persons.AddAsync(person);
                await _ctx.SaveChangesAsync();
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
                return await _ctx.Persons.AsNoTracking().ToListAsync();
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
                return await _ctx.Persons.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new PersonRepositoryException(nameof(FindAsync), ex);
            }
        }

        public async void Remove(Person person)
        {
            try
            {
                _ctx.Persons.Remove(person);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new PersonRepositoryException(nameof(Remove), ex);
            }
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            try
            {
                _ctx.Persons.Update(person);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new PersonRepositoryException(nameof(UpdateAsync), ex);
            }

            return person;
        }
    }
}
