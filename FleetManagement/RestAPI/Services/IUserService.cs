using RestAPI.Authentication;

namespace RestAPI.Services
{
    public interface IUserService
    {
        Task<LoginReponse> Authenticate(UserLogin login);
    }
}
