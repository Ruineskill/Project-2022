using Domain.Models;
using Presentation.HttpClients;
using Presentation.Interfaces;
using Shared.ApiRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<bool> CreateAsync(Person obj)
        {
            var result = await _client.PostAsync(PersonRoute.CreatePath, obj);
            return result == HttpStatusCode.OK;
        }

        public async Task<bool> DeleteAsync(Person obj)
        {
            var result = await _client.DeleteAsync(PersonRoute.DeletePath(obj.Id));
            return result == HttpStatusCode.OK;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _client.GetAsync<IEnumerable<Person>>(PersonRoute.GetAllPath);
        }

        public IAsyncEnumerable<Person> GetAllStream()
        {
            return _client.GetAllStream<Person>(PersonRoute.GetAllStreamPath);
        }

        public async Task<Person> GetAsync(int id)
        {
            return await _client.GetAsync<Person>(PersonRoute.GetByIdPath(id));
        }

        public async Task<bool> UpdateAsync(Person obj)
        {
            var result = await _client.PutAsync(PersonRoute.UpdatePath, obj);
            return result == HttpStatusCode.OK;
        }
    }
}
