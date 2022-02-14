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
        public UserService(SchoolApiContext _context, IOptions<AppSettings> _appSettings, IConfiguration Configuration)
        {
            this._context = _context;
            this._appSettings = _appSettings.Value;
            this.Configuration = Configuration;
        }


        //Generates Jwt Token for given user.
        public string GenerateJwtToken(User User)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, User.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = TokenHandler.CreateToken(TokenDescriptor);

            return TokenHandler.WriteToken(Token);
        }
    }
}
