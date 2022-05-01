﻿#nullable disable
using Presentation.Constants;
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
            _httpClient.BaseAddress = new Uri(HttpPaths.Base);
            _jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            _jsonOptions.Converters.Add(new DateOnlyConverter());
          
        }

        public Task<T> GetAsync<T>(string uri)
        {
            return _httpClient.GetFromJsonAsync<T>(HttpPaths.Base + uri, _jsonOptions);
        }

        public async Task<T> PostAsync<T>(string uri, T payLoad)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, payLoad, _jsonOptions);

            return await HttpContentJsonExtensions.ReadFromJsonAsync<T>(response.Content);
        }

        public void AddRequestHeader(string attributeName, string attributeContent)
        {
            _httpClient.DefaultRequestHeaders.Add(attributeName, attributeContent);
        }

        public void ClearRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task<T> PostAsync<T, O>(string uri, O payLoad)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, payLoad, _jsonOptions);

            return await HttpContentJsonExtensions.ReadFromJsonAsync<T>(response.Content);
        }

        public async Task<T> PutAsync<T>(string uri, T payLoad)
        {
            var response = await _httpClient.PutAsJsonAsync(uri, payLoad, _jsonOptions);

            return await HttpContentJsonExtensions.ReadFromJsonAsync<T>(response.Content);
        }

        public async Task<System.Net.HttpStatusCode> DeleteAsync(string uri, StringContent payLoad)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Delete, _httpClient.BaseAddress + uri)
            {
                Content = payLoad,
            };

            var result = await _httpClient.SendAsync(httpMessage);

            return result.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAsync(string uri)
        {
            var response = await _httpClient.DeleteAsync(uri);
            return response.StatusCode;
        }
    }
}