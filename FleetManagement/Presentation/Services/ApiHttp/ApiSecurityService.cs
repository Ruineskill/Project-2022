#nullable disable warnings
using Presentation;
using Presentation.HttpClients;
using Presentation.Interfaces.ApiHttp;
using Shared.ApiRoutes;
using Shared.Authentication;
using System.Net;
using System.Security;
using System.Threading.Tasks;

namespace Presentation.Services.ApiHttp
{
    public class ApiSecurityService : IApiSecurityService
    {
        private AuthenticationResponse _authenticationInfo;

        private readonly ApiHttpClient _client;

        public string CurrentUser => _authenticationInfo.UserName;

        public string Message => _authenticationInfo.Message;

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


            _authenticationInfo = await _client.PostAsync<AuthenticationResponse, SignInRequest>(UserRoute.Base + UserRoute.SignIn, signin);
            _client.AddRequestHeader("Authorization", "Bearer " + _authenticationInfo?.Token);
            signin.Password = string.Empty;
            password.Dispose();

            return _authenticationInfo.IsAuthenticated;
        }

        public async Task SignOut()
        {

            await _client.DeleteAsync(UserRoute.Base + UserRoute.SignOut);
        }
    }
}
