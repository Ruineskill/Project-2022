using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using Shared.Authentication;

namespace Shared.Controllers
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
        [HttpPost(ApiRoutes.UserRoute.SignIn)]
        public async Task<ActionResult<AuthenticationReponse>> UserSignIn(SignInRequest login)
        {
            var reponse = await _userService.Authenticate(login);

            if (reponse == null)
            {
                return BadRequest(new AuthenticationReponse("Username/password is incorrect"));
            }

            return Ok(reponse);
        }


        [HttpPost(ApiRoutes.UserRoute.RefreshToken)]
        public async Task<ActionResult<AuthenticationReponse>> RefreshToken(RefreshRequest refresh)
        {

            var user = await _userService.GetUser(User);
            if (user == null) return BadRequest();

            var isValid = _userService.Validate(user, refresh.Token);
            if (!isValid) return BadRequest();

            var reponse = await _userService.Refresh(user, refresh.Token);

            return Ok(reponse);
        }


        [HttpDelete(ApiRoutes.UserRoute.SignOut)]
        public async Task<IActionResult> UserSignOut()
        {
            var user = await _userService.GetUser(User);
            if (user == null) return BadRequest();
            _userService.RemoveRefreshToken(user);
       
            
            return Ok();
        }

    }
}
