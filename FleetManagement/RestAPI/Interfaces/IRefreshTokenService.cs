using Microsoft.AspNetCore.Identity;

namespace RestAPI.Interfaces
{
    public interface IRefreshTokenService
    {
        string Generate();
    }
}
