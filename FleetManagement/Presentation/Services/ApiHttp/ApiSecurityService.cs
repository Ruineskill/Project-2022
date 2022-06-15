#nullable disable warnings
using Presentation;
using Presentation.HttpClients;
using Presentation.Interfaces.ApiHttp;
using Shared.ApiRoutes;
using Shared.Authentication;
using System;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Timers;

namespace Presentation.Services.ApiHttp
{
    public class ApiSecurityService : IApiSecurityService
    {
        private Timer _timer;
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

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            var refresh = new RefreshRequest() { Token = _authenticationInfo.Token };
            _authenticationInfo = _client.PostAsync<AuthenticationResponse, RefreshRequest>(UserRoute.Base + UserRoute.RefreshToken, refresh).Result;
        }



        public void StartTimer()
        {
            // Create a timer and set a two second interval.
            _timer = new System.Timers.Timer();
            _timer.Interval = 540;

            // Hook up the Elapsed event for the timer. 
            _timer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            _timer.AutoReset = true;

            // Start the timer
            _timer.Enabled = true;

        }
    }
}
