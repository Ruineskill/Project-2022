using Domain.Models;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class HttpPersonService : IHttpPersonService
    {
        public Task<Car> CreateAsync(Car obj)
        {
            throw new NotImplementedException();
        }

        public Task<Person> CreateAsync(Person obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Car obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Person obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Car> UpdateAsync(Car obj)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateAsync(Person obj)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Person>> IHttpObject<Person>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Person> IHttpObject<Person>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
