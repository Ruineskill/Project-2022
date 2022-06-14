using Presentation.DTO;
using Presentation.HttpClients;
using Presentation.Interfaces.ApiHttp;
using Shared.ApiRoutes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Services.ApiHttp
{
    public class HttpCarService : IHttpCarService
    {
        private readonly ApiHttpClient _client;

        public HttpCarService(ApiHttpClient client)
        {
            _client = client;
        }

        public async Task<CarDto> CreateAsync(CarDto obj)
        {
            return await _client.PostAsync(CarRoute.CreatePath, obj);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync(CarRoute.DeletePath(id));
        }

        public async Task<IEnumerable<CarDto>> GetAllAsync()
        {
            return await _client.GetAsync<IEnumerable<CarDto>>(CarRoute.GetAllPath);
        }


        public IAsyncEnumerable<CarDto> GetAllStream()
        {
            return _client.GetAllStream<CarDto>(CarRoute.GetAllStreamPath);
        }

        public async Task<CarDto> GetAsync(int id)
        {
            return await _client.GetAsync<CarDto>(CarRoute.GetByIdPath(id));
        }

        public async Task UpdateAsync(CarDto obj)
        {
            await _client.PutAsync(CarRoute.UpdatePath, obj);
        }
    }
}
