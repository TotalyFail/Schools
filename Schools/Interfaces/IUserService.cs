using SchoolApi.Models;

namespace SchoolApi.Interfaces
{
    interface IUserService
    {
        public string GenerateJwtToken(User User);
    }
}
