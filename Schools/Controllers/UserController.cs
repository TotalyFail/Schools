using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolApi.Helpers;
using SchoolApi.Models;
using SchoolApi.Services;


namespace SchoolApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        private readonly UserService _userService;

        public UserController(UserService _userService, IConfiguration Configuration)
        {
            this._userService = _userService;
            this.Configuration = Configuration;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User Model)
        {
            OperationResult result = _userService.Authenticate(Model);
            if (result.Success == false)
                return BadRequest(result.FailureMessage);

            return Ok(_userService.GenerateJwtToken(Model));
        }
    }
}
