using Microsoft.AspNetCore.Identity;

namespace RestAPI.Interfaces
{
    public interface ITokenService
    {
        Task<string> Generate(IdentityUser user);
    }
}
