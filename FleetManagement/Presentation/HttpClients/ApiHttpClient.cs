#nullable disable
using Presentation.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Presentation.HttpClients
{
    public class ApiHttpClient : HttpClient , IApiHttpClient
    {
        public ApiHttpClient()
        {
            BaseAddress = new Uri(HttpPaths.Base);
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            return await this.GetFromJsonAsync<T>(uri);
        }

        public async Task<T> PostAsync<T>(string uri, T payLoad)
        {
            var response = await this.PostAsJsonAsync(uri, payLoad);

            return await HttpContentJsonExtensions.ReadFromJsonAsync<T>(response.Content);
        }

        public async Task<T> PostAsync<T,O>(string uri, O payLoad)
        {
            var response = await this.PostAsJsonAsync(uri, payLoad);

            return await HttpContentJsonExtensions.ReadFromJsonAsync<T>(response.Content);
        }

        public async Task<T> PutAsync<T>(string uri, T payLoad)
        {
            var response = await this.PutAsJsonAsync(uri, payLoad);

            return await HttpContentJsonExtensions.ReadFromJsonAsync<T>(response.Content);
        }

        public async Task<System.Net.HttpStatusCode> DeleteAsync(string uri, StringContent payLoad)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Delete, BaseAddress + uri)
            {
                Content = payLoad,
            };

            var result = await this.SendAsync(httpMessage);

            return result.StatusCode;
        }
    }
}
