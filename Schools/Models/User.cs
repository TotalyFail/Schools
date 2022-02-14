using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models
{
    public class User
    {
        [EmailAddress]
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
