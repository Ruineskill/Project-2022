using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authentication;
using RestAPI.Interfaces;

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
        [HttpPost("SignIn")]
        public async Task<ActionResult<AuthenticationReponse>> SignIn(SignInRequest login)
        {
            var reponse = await _userService.Authenticate(login);

            if (reponse == null)
            {
                return BadRequest(new AuthenticationReponse("Username/password is incorrect"));
            }

            return Ok(reponse);
        }


        [HttpPost("Refresh")]
        public async Task<ActionResult<AuthenticationReponse>> Refresh(RefreshRequest refresh)
        {

            var user = await _userService.GetUser(User);
            if (user == null) return BadRequest();

            var isValid = _userService.Validate(user, refresh.Token);
            if (!isValid) return BadRequest();

            var reponse = await _userService.Refresh(user, refresh.Token);

            return Ok(reponse);
        }


        [HttpDelete("Invalidate")]
        public async Task<IActionResult> Invalidate()
        {
            var user = await _userService.GetUser(User);
            if (user == null) return BadRequest();
            _userService.RemoveRefreshToken(user);
       
            
            return Ok();
        }

    }
}
