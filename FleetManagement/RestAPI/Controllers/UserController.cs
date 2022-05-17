using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Authentication;
using Shared.Interfaces;

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
        public async Task<ActionResult<AuthenticationResponse>> UserSignIn(SignInRequest login)
        {
            // Because this is authentication method(s),
            // no exception messages are returned, which could reveal inner structures of the API security.

            try
            {
                var reponse = await _userService.Authenticate(login);

                if (reponse == null)
                {
                    return BadRequest(new AuthenticationResponse("Username/password is incorrect"));
                }

                return Ok(reponse);
            }
            catch (Exception)
            {
                return BadRequest("Unexpected error occurred");
            }
        }


        [HttpPost(ApiRoutes.UserRoute.RefreshToken)]
        public async Task<ActionResult<AuthenticationResponse>> RefreshToken(RefreshRequest refresh)
        {
            // Because this is authentication method(s),
            // no exception messages are returned, which could reveal inner structures of the API security.

            try
            {
                var user = await _userService.GetUser(User);
                if (user == null) return BadRequest();

                var isValid = await _userService.Validate(user, refresh.Token);
                if (!isValid) return BadRequest();

                var reponse = await _userService.Refresh(user, refresh.Token);

                return Ok(reponse);
            }
            catch (Exception)
            {
                return BadRequest("Unexpected error occurred");
            }

           
        }


        [HttpDelete(ApiRoutes.UserRoute.SignOut)]
        public async Task<IActionResult> UserSignOut()
        {
            // Because this is authentication method(s),
            // no exception messages are returned, which could reveal inner structures of the API security.

            try
            {
                var user = await _userService.GetUser(User);

                if (user == null) return BadRequest();

                await _userService.RemoveRefreshToken(user);
            }
            catch (Exception)
            {

                return BadRequest("Unexpected error occurred");
            }

            return Ok();
        }

    }
}
