using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authentication;
using RestAPI.Services;

namespace RestAPI.Controllers
{
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
        public async Task<IActionResult> Authenticate(UserLogin login)
        {
            var response = await _userService.Authenticate(login);

            if(response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
      
    }
}
