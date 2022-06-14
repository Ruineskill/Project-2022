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
using Presentation.Exceptions;
using Presentation.Interfaces.ApiHttp;

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

        public async Task<T> GetAsync<T>(string uri)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(uri, _jsonOptions);
            }
            catch(Exception ex)
            {

                throw new ApiException(ex.Message);
            }
        }

        public async Task<T> PostAsync<T>(string uri, T payLoad)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(uri, payLoad, _jsonOptions);
                response.EnsureSuccessStatusCode();
                return await HttpContentJsonExtensions.ReadFromJsonAsync<T>(response.Content);
            }
            catch(Exception ex)
            {

                throw new ApiException(ex.Message);
            }
        }

        public async Task<R> PostAsync<R, T>(string uri, T payLoad)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(uri, payLoad, _jsonOptions);
                response.EnsureSuccessStatusCode();

                return await HttpContentJsonExtensions.ReadFromJsonAsync<R>(response.Content);
            }
            catch(Exception ex)
            {

                throw new ApiException(ex.Message);
            }
        }


        public void AddRequestHeader(string attributeName, string attributeContent)
        {
            _httpClient.DefaultRequestHeaders.Add(attributeName, attributeContent);
        }

        public void ClearRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task PutAsync<T>(string uri, T payLoad)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(uri, payLoad, _jsonOptions);
                response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {

                throw new ApiException(ex.Message);
            }
        }

        public async Task DeleteAsync(string uri)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(uri);
                response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {

                throw new ApiException(ex.Message);
            }
        }


        public async IAsyncEnumerable<T> GetAllStream<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {

                throw new ApiException(ex.Message);
            }

            var responseStream = await response.Content.ReadAsStreamAsync();
            var items = JsonSerializer.DeserializeAsyncEnumerable<T>(responseStream, _jsonOptions);


            await foreach(var item in items)
            {
                yield return item;
            }


        }
    }
}
