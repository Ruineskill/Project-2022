#nullable disable
namespace RestAPI.Authentication
{
    public class SignInRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
