using Presentation.DTO;
using Presentation.HttpClients;
using Presentation.Interfaces.ApiHttp;
using Shared.ApiRoutes;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.Services.ApiHttp
{
    public class HttpFuelCardService : IHttpFuelCardService
    {

        private readonly ApiHttpClient _client;

        public HttpFuelCardService(ApiHttpClient client)
        {
            _client = client;
        }

        public async Task<FuelCardDto> CreateAsync(FuelCardDto obj)
        {
            return await _client.PostAsync(FuelCardRoute.CreatePath, obj);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync(FuelCardRoute.DeletePath(id));
        }

        public async Task<IEnumerable<FuelCardDto>> GetAllAsync()
        {
            return await _client.GetAsync<IEnumerable<FuelCardDto>>(FuelCardRoute.GetAllPath);
        }

        public IAsyncEnumerable<FuelCardDto> GetAllStream()
        {
            return _client.GetAllStream<FuelCardDto>(FuelCardRoute.GetAllStreamPath);
        }

        public async Task<FuelCardDto> GetAsync(int id)
        {
            return await _client.GetAsync<FuelCardDto>(FuelCardRoute.GetByIdPath(id));
        }

        public async Task UpdateAsync(FuelCardDto obj)
        {
            await _client.PutAsync(FuelCardRoute.UpdatePath, obj);
        }
    }
}
