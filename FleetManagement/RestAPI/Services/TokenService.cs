using Microsoft.AspNetCore.Identity;
using RestAPI.Interfaces;
using System.Security.Claims;
using System.Text;

namespace RestAPI.Services
{
    public class TokenService : ITokenService
    {
       
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManger;

        public TokenService(ITokenGenerator tokenGenerator, IConfiguration configuration, UserManager<IdentityUser> userManger)
        {
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;
            _userManger = userManger;
        }

        public string Generate(IdentityUser user)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };

            // get role
            var roles = _userManger.GetRolesAsync(user).Result;
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var secretKey = Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]);
            var issuer = _configuration["AuthSettings:Issuer"];
            var audience = _configuration["AuthSettings:Audience"];
            var expires = DateTime.Now.AddMinutes(double.Parse(_configuration["AuthSettings:AccesTokenExpirationMinutes"]));

            return _tokenGenerator.Generate(secretKey, issuer, audience, expires, claims);
        }
    }
}
