using Microsoft.AspNetCore.Identity;
using RestAPI.Authentication;
using System.Security.Claims;

namespace RestAPI.Services
{
    public interface IUserService
    {
        Task<IdentityUser?> Authenticate(UserLogin login);
        Task<List<Claim>> CreateClaimsForUser(IdentityUser user);
        string CreateTokenFromClaims(List<Claim> claims);
    }
}
