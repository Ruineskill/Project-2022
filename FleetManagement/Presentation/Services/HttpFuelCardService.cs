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
    public class HttpFuelCardService : IHttpFuelCardService
    {

        private readonly ApiHttpClient _client;

        public HttpFuelCardService(ApiHttpClient client)
        {
            _client = client;
        }

        public async Task<bool> CreateAsync(FuelCard obj)
        {
            var result = await _client.PostAsync(FuelCardRoute.CreatePath, obj);
            return result == HttpStatusCode.OK;
        }

        public async Task<bool> DeleteAsync(FuelCard obj)
        {
            var result = await _client.DeleteAsync(FuelCardRoute.DeletePath(obj.Id));
            return result == HttpStatusCode.OK;
        }

        public async Task<IEnumerable<FuelCard>> GetAllAsync()
        {
            return await _client.GetAsync<IEnumerable<FuelCard>>(FuelCardRoute.GetAllPath);
        }

        public IAsyncEnumerable<FuelCard> GetAllStream()
        {
            return _client.GetAllStream<FuelCard>(FuelCardRoute.GetAllStreamPath);
        }

        public async Task<FuelCard> GetAsync(int id)
        {
            return await _client.GetAsync<FuelCard>(FuelCardRoute.GetByIdPath(id));
        }

        public async Task<bool> UpdateAsync(FuelCard obj)
        {
            var result = await _client.PutAsync(FuelCardRoute.UpdatePath, obj);
            return result == HttpStatusCode.OK;
        }
    }
}
