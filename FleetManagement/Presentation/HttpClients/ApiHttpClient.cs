#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json;
using Domain.JsonConverters;

namespace Presentation.HttpClients
{
    public class ApiHttpClient : IApiHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiHttpClient(HttpClient httpClient)
        {

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(Shared.ApiRoutes.BaseRoute.Base);

            _jsonOptions = new JsonSerializerOptions();
            _jsonOptions.Converters.Add(new DateOnlyConverter());
            _jsonOptions.PropertyNameCaseInsensitive = true;
            _jsonOptions.DefaultBufferSize = 500;

        }

        public Task<T> GetAsync<T>(string uri)
        {
            return _httpClient.GetFromJsonAsync<T>(uri, _jsonOptions);
        }

        public async Task<HttpStatusCode> PostAsync<T>(string uri, T payLoad)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, payLoad, _jsonOptions);
            return response.StatusCode;
        }

        public async Task<R> PostAsync<R, T>(string uri, T payLoad)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, payLoad, _jsonOptions);
            response.EnsureSuccessStatusCode();


            return await HttpContentJsonExtensions.ReadFromJsonAsync<R>(response.Content);
        }


        public void AddRequestHeader(string attributeName, string attributeContent)
        {
            _httpClient.DefaultRequestHeaders.Add(attributeName, attributeContent);
        }

        public void ClearRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task<HttpStatusCode> PutAsync<T>(string uri, T payLoad)
        {
            var response = await _httpClient.PutAsJsonAsync(uri, payLoad, _jsonOptions);

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAsync(string uri)
        {
            var response = await _httpClient.DeleteAsync(uri);
            return response.StatusCode;
        }


        public async IAsyncEnumerable<T> GetAllStream<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
     
            var responseStream = await response.Content.ReadAsStreamAsync();
            var items = JsonSerializer.DeserializeAsyncEnumerable<T>(responseStream, _jsonOptions);


            await foreach(var item in items)
            {
                yield return item;
            }


        }
    }
}
