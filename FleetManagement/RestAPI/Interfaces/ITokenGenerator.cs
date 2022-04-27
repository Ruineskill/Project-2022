using System.Security.Claims;

namespace RestAPI.Interfaces
{
    public interface ITokenGenerator
    {
        string Generate(byte[] key, string? issuer, string? audience, DateTime? expirationTime, List<Claim>? claims =null);
    }
}
