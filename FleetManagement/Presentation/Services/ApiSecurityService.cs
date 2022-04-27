using Domain.Models;
using System.Text.Json;
using Presentation.Constants;
using Presentation.Dto;
using Presentation.HttpClients;
using Presentation.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class ApiSecurityService : IApiSecurityService
    {
        private AuthenticationReponse? _authenticationInfo;

        private readonly ApiHttpClient _client;


        public ApiSecurityService(ApiHttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<bool> SignIn(string username, SecureString password)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var signin = new SignInRequest()
            {
                UserName = username,
                Password = new System.Net.NetworkCredential(string.Empty, password).Password
            };


            try
            {
                _authenticationInfo = await _client.PostAsync<AuthenticationReponse, SignInRequest>(HttpPaths.SignIn, signin);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authenticationInfo?.Token);

            }
            catch(Exception)
            {

                return false;
            }


            return true;

        }

        public async void SignOut()
        {
            await _client.DeleteAsync(HttpPaths.SignOut);

        }
    }
}
