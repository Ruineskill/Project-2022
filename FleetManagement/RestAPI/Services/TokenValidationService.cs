using Microsoft.IdentityModel.Tokens;
using RestAPI.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RestAPI.Services
{
    public class TokenValidationService : ITokenValidationService
    {
        private readonly IConfiguration _configuration;

        public TokenValidationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Validate(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = _configuration["AuthSettings:Audience"],
                ValidIssuer = _configuration["AuthSettings:Issuer"],
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:RefreshKey"])),
                ClockSkew = TimeSpan.Zero,

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
    }
}
