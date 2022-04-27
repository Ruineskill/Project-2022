using Microsoft.AspNetCore.Identity;
using RestAPI.Interfaces;
using System.Text;

namespace RestAPI.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IConfiguration _configuration;

        public RefreshTokenService(ITokenGenerator tokenGenerator, IConfiguration configuration)
        {
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;
        }

        public string Generate()
        {
            var secretKey = Encoding.UTF8.GetBytes(_configuration["AuthSettings:RefreshKey"]);
            var issuer = _configuration["AuthSettings:Issuer"];
            var audience = _configuration["AuthSettings:Audience"];
            var expires = DateTime.Now.AddMinutes(double.Parse(_configuration["AuthSettings:RefreshTokenExpirationMinutes"]));

            return _tokenGenerator.Generate(secretKey, issuer, audience, expires);
        }
    }
}
