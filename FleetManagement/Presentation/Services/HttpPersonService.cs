using Domain.Models;
using Presentation.HttpClients;
using Presentation.Interfaces;
using Shared.ApiRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class HttpPersonService : IHttpPersonService
    {
        private readonly ApiHttpClient _client;

        public HttpPersonService(ApiHttpClient client)
        {
            _client = client;
        }

        public Task<Person> CreateAsync(Person obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Person obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _client.GetAsync<IEnumerable<Person>>(PersonRoute.Base + PersonRoute.GetAll);
        }

        public IAsyncEnumerable<Person> GetAllStream()
        {
            return _client.GetAllStream<Person>(PersonRoute.Base + PersonRoute.GetAllStream);
        }

        public Task<Person> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateAsync(Person obj)
        {
            throw new NotImplementedException();
        }
    }
}
