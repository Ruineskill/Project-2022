using Microsoft.AspNetCore.Identity;
using RestAPI.Authentication;
using System.Security.Claims;

namespace RestAPI.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationReponse?> Authenticate(SignInRequest login);

        Task<IdentityUser?> GetUser(ClaimsPrincipal principal);

        bool Validate(IdentityUser user, string token);
        Task<AuthenticationReponse?> Refresh(IdentityUser user, string token);
        void RemoveRefreshToken(IdentityUser user);
    }
}
