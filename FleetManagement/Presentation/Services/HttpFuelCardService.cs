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
    public class HttpFuelCardService : IHttpFuelCardService
    {

        private readonly ApiHttpClient _client;

        public HttpFuelCardService(ApiHttpClient client)
        {
            _client = client;
        }

        public Task<FuelCard> CreateAsync(FuelCard obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(FuelCard obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FuelCard>> GetAllAsync()
        {
            return await _client.GetAsync<IEnumerable<FuelCard>>(FuelCardRoute.Base + FuelCardRoute.GetAll);
        }

        public IAsyncEnumerable<FuelCard> GetAllStream()
        {
            return _client.GetAllStream<FuelCard>(FuelCardRoute.Base + FuelCardRoute.GetAllStream);
        }

        public Task<FuelCard> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FuelCard> UpdateAsync(FuelCard obj)
        {
            throw new NotImplementedException();
        }
    }
}
