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

        public UserService()
        {
        }

        public OperationResult Authenticate([FromBody] User model)
        {
            User User = new User(AppSettings.Username, AppSettings.Password);

            if (User == null)
                return OperationResult.FailureResult("Username or password is incorrect");
            else if (User.Username != model.Username || User.Password != model.Password)
                return OperationResult.FailureResult("User not found");
            else if (User.Password.Length < 12)
                return OperationResult.FailureResult("Password is too short");

            return OperationResult.SuccessResult();
        }

        //Generates Jwt Token for given user.
        public string GenerateJwtToken(User user)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = TokenHandler.CreateToken(TokenDescriptor);

            return TokenHandler.WriteToken(Token);
        }
    }
}