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
    public class HttpCarService : IHttpCarService
    {
        private readonly ApiHttpClient _client;

        public HttpCarService(ApiHttpClient client)
        {
            _client = client;
        }

        public async Task<bool> CreateAsync(Car obj)
        {
            var result = await _client.PostAsync(CarRoute.CreatePath, obj);
            return result == HttpStatusCode.OK;
        }

        public async Task<bool> DeleteAsync(Car obj)
        {
          
            var result  = await _client.DeleteAsync(CarRoute.DeletePath(obj.Id));
            return result == HttpStatusCode.OK;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _client.GetAsync<IEnumerable<Car>>(CarRoute.GetAllPath);
        }


        public IAsyncEnumerable<Car> GetAllStream()
        {
            return _client.GetAllStream<Car>(CarRoute.GetAllStreamPath);

        }

        public async Task<Car> GetAsync(int id)
        {
            return await _client.GetAsync<Car>(CarRoute.GetByIdPath(id));
        }

        public async Task<bool> UpdateAsync(Car obj)
        {
            var result = await _client.PutAsync(CarRoute.UpdatePath, obj);
            return result == HttpStatusCode.OK;
        }
    }
}
