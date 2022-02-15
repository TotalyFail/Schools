using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        public IConfiguration Configuration { get; }

        public UserService(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public OperationResult Authenticate([FromBody] User Model)
        {
            User User = new User(Configuration.GetValue<string>("Auth:Username"), Configuration.GetValue<string>("Auth:Password"));

            if (User == null)
                return OperationResult.FailureResult("Username or password is incorrect");
            else if (User.Username != Model.Username || User.Password != Model.Password)
                return OperationResult.FailureResult("User not found");
            else if (User.Password.Length < 12)
                return OperationResult.FailureResult("Password is too short");

            return OperationResult.SuccessResult();
        }

        //Generates Jwt Token for given user.
        public string GenerateJwtToken(User User)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(AppSettings.Secret);
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