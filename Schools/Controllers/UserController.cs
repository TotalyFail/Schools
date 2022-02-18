using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Helpers;
using SchoolApi.Models;
using SchoolApi.Services;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService _userService)
        {
            this._userService = _userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User model)
        {
            await Task.Delay(500);
            OperationResult result = _userService.Authenticate(model);
            if (result.Success == false)
                return BadRequest(result.FailureMessage);

            return Ok(_userService.GenerateJwtToken(model));
        }
    }
}