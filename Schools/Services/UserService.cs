using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Data;
using SchoolApi.Helpers;
using SchoolApi.Interfaces;
using SchoolApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        SchoolApiContext _context;
        public IConfiguration Configuration { get; }
        public UserService(SchoolApiContext _context, IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            this._context = _context;
            this._appSettings = appSettings.Value;
            this.Configuration = configuration;
        }

        //Generates Jwt Token for given user.
        public string GenerateJwtToken(User user)
        {
            _appSettings.Secret = Configuration.GetValue<string>("AppSettings:Secret");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
