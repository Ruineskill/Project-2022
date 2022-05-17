using Microsoft.AspNetCore.Identity;
using RestAPI.Authentication;
using Shared.Authentication;
using System.Security.Claims;

namespace RestAPI.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponse?> Authenticate(SignInRequest login);

        Task<IdentityUser?> GetUser(ClaimsPrincipal principal);

        Task<bool> Validate(IdentityUser user, string token);
        Task<AuthenticationResponse?> Refresh(IdentityUser user, string token);
        Task RemoveRefreshToken(IdentityUser user);
    }
}
