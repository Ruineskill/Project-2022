using Microsoft.IdentityModel.Tokens;
using RestAPI.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestAPI.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public string Generate(byte[] key, string? issuer, string? audience, DateTime? expirationTime, List<Claim>? claims = null)
        {
            var symmetricKey = new SymmetricSecurityKey(key);

            var token = new JwtSecurityToken(
               issuer: issuer,
               audience: audience,
               notBefore: DateTime.Now,
               claims: claims,
               expires: expirationTime,
               signingCredentials: new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
