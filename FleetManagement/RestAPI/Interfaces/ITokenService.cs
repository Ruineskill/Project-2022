using Microsoft.AspNetCore.Identity;

namespace RestAPI.Interfaces
{
    public interface ITokenService
    {
        Task<String> Generate(IdentityUser user);
    }
}
