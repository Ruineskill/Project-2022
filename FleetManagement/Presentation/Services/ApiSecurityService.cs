#nullable disable warnings
using Domain.Models;
using System.Text.Json;
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
using Shared.Authentication;
using Shared.ApiRoutes;
using System.Net;

namespace Presentation.Services
{
    public class ApiSecurityService : IApiSecurityService
    {
        private AuthenticationResponse _authenticationInfo;

        private readonly ApiHttpClient _client;


        public ApiSecurityService(ApiHttpClient httpClient)
        {
            _client = httpClient;
            _authenticationInfo = new AuthenticationResponse();
        }

        public async Task<bool> SignIn(string username, SecureString password)
        {


            _client.ClearRequestHeaders();
            _client.AddRequestHeader("Accept", "application/json");

            var signin = new SignInRequest()
            {
                UserName = username,
                Password = new NetworkCredential(string.Empty, password).Password
            };

            try
            {
                _authenticationInfo = await _client.PostAsync<AuthenticationResponse, SignInRequest>(UserRoute.Base + UserRoute.SignIn, signin);
                _client.AddRequestHeader("Authorization", "Bearer " + _authenticationInfo?.Token);
                signin.Password = string.Empty;
                password.Dispose();
                return _authenticationInfo.IsAuthenticated;

            }
            catch(Exception)
            {
                signin.Password = string.Empty;
                return false;
            }

        }

        public async Task<bool> SignOut()
        {
            var result = await _client.DeleteAsync(UserRoute.Base + UserRoute.SignOut);

            return result == HttpStatusCode.OK;
        }
    }
}
