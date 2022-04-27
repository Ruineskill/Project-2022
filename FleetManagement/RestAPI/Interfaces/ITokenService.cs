using Microsoft.AspNetCore.Identity;

namespace RestAPI.Interfaces
{
    public interface ITokenService
    {
        string Generate(IdentityUser user);
    }
}
