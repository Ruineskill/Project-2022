#nullable disable


namespace RestAPI.Authentication
{
    public class LoginReponse
    {
        public string UserName { get; set; }  = string.Empty;

        public string Token { get; set; } = string.Empty;

        public bool IsAuthenticated { get; set; } = false;

        public string Message { get; set; } = string.Empty;


        public LoginReponse() { }
        public LoginReponse(string message)
        {
            Message = message;
        }
    }
}
