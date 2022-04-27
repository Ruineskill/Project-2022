using Domain.Models;
using Presentation.Constants;
using Presentation.HttpClients;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class HttpCarService : IHttpCarService
    {
        private readonly ApiHttpClient _client;

        public HttpCarService(ApiHttpClient client)
        {
            _client = client;
        }

        public Task<Car> CreateAsync(Car obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Car obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _client.GetAsync<IEnumerable<Car>>(HttpPaths.GetAllCars);
        }

        public Task<Car> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Car> UpdateAsync(Car obj)
        {
            throw new NotImplementedException();
        }
    }
}
