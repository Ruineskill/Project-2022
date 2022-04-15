using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authentication;
using RestAPI.Services;

namespace RestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Authentication")]
        public async Task<ActionResult<LoginReponse>> Authenticate(UserLogin login)
        {
            var user = await _userService.Authenticate(login);

            if(user == null)
                return BadRequest(new LoginReponse( "Username/password is incorrect" ));

            var claims = await _userService.CreateClaimsForUser(user);
            LoginReponse reponse = new()
            {
                IsAuthenticated = true,
                UserName = login.UserName,
                Token = _userService.CreateTokenFromClaims(claims)
            };


            return Ok(reponse);
        }

    }
}
