using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RestAPI.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestAPI.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManger;
        //RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;


        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManger = userManager;
            //_roleManager = roleManager;
            _configuration = configuration;
        }


        public async Task<LoginReponse> Authenticate(UserLogin login)
        {
            // check username
            var user = await _userManger.FindByNameAsync(login.UserName);

            if(user == null) return new LoginReponse("Username not found!");

            // check password
            var result = await _userManger.CheckPasswordAsync(user, login.Password);

            if(!result) return new LoginReponse("Password is not correct!");

            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            // get role
            var roles  = await _userManger.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);


            return new LoginReponse
            {
                UserName = login.UserName,
                Token = tokenAsString,
                IsAuthenticated = true,
            };
        }

    }
}
