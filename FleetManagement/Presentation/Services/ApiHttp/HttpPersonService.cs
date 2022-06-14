using Domain.Models;
using Presentation.DTO;
using Presentation.HttpClients;
using Presentation.Interfaces.ApiHttp;
using Shared.ApiRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services.ApiHttp
{
    public class HttpPersonService : IHttpPersonService
    {
        private readonly ApiHttpClient _client;

        public HttpPersonService(ApiHttpClient client)
        {
            _client = client;
        }

        public async Task<PersonDto> CreateAsync(PersonDto obj)
        {
            return await _client.PostAsync(PersonRoute.CreatePath, obj);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync(PersonRoute.DeletePath(id));
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            return await _client.GetAsync<IEnumerable<PersonDto>>(PersonRoute.GetAllPath);
        }

        public IAsyncEnumerable<PersonDto> GetAllStream()
        {
            return _client.GetAllStream<PersonDto>(PersonRoute.GetAllStreamPath);
        }

        public async Task<PersonDto> GetAsync(int id)
        {
            return await _client.GetAsync<PersonDto>(PersonRoute.GetByIdPath(id));
        }

        public async Task UpdateAsync(PersonDto obj)
        {
            await _client.PutAsync(PersonRoute.UpdatePath, obj);
        }
    }
}
