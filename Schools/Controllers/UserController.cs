using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

        public UserController(UserService _userService, IConfiguration configuration)
        {
            this._userService = _userService;
            this.Configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User Model)
        {
            User User = new User(Configuration.GetValue<string>("Auth:Username"), Configuration.GetValue<string>("Auth:Password"));

            if (User.Username != Model.Username || User.Password != Model.Password)
                return BadRequest(new { message = "Username or password is incorrect" });
            else if (User == null)
                return BadRequest(new { message = "User = null" });
            else if (User.Password.Length < 12)
                return BadRequest(new { message = "Password is too short" });

            string Token = _userService.GenerateJwtToken(User);
            return Ok(Token);
        }
    }
}
