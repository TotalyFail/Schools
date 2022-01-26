using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models
{
    public class User
    {
        [EmailAddress]
        public string username { get; set; }
        public string password { get; set; }

        public User() { }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
