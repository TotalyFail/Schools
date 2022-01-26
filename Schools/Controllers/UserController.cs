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
        private readonly UserService userService;

        public UserController(UserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.Configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User model)
        {
            User user = new User(Configuration.GetValue<string>("Auth:Username"), Configuration.GetValue<string>("Auth:Password"));

            if (user.username != model.username || user.password != model.password)
                return BadRequest(new { message = "Username or password is incorrect" });
            else if (user == null)
                return BadRequest(new { message = "User = null" });
            else if (user.password.Length < 12)
                return BadRequest(new { message = "Password is too short" });

            string token = userService.GenerateJwtToken(user);
            return Ok(token);
        }
    }
}
