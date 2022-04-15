using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestAPI.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManger;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManger = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityUser?> Authenticate(UserLogin login)
        {
            // check username
            var user = await _userManger.FindByNameAsync(login.UserName);

            if(user != null)
            {
                if(await _userManger.CheckPasswordAsync(user, login.Password))
                {
                    return user;

                }
            }
            return null;
        }

        public async Task<List<Claim>> CreateClaimsForUser(IdentityUser user)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };


            // get role
            var roles = await _userManger.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        public string CreateTokenFromClaims(List<Claim> claims)
        {
            var secretKey = Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]);
            var symmetricKey = new SymmetricSecurityKey(secretKey);

            var token = new JwtSecurityToken(
               issuer: _configuration["AuthSettings:Issuer"],
               audience: _configuration["AuthSettings:Audience"],
               claims: claims,
               expires: DateTime.Now.AddDays(30),
               signingCredentials: new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
