using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        private readonly UserServiceImpl userService;

        public UserController(UserServiceImpl userService, IConfiguration configuration)
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
                return BadRequest(new { message = "Password too short"});

            string token = userService.GenerateJwtToken(user);
            return Ok(token);
        }
    }
}
