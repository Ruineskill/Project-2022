#nullable disable


namespace Shared.Authentication
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }  = string.Empty;

        public string Token { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;

        public bool IsAuthenticated { get; set; } = false;

        public string Message { get; set; } = string.Empty;


        public AuthenticationResponse() { }
        public AuthenticationResponse(string message)
        {
            Message = message;
        }
    }
}
