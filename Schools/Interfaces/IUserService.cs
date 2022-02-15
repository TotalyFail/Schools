using SchoolApi.Models;

namespace SchoolApi.Interfaces
{
    internal interface IUserService
    {
        public string GenerateJwtToken(User user);
    }
}