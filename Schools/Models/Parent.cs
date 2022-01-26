using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models
{
    public class Parent
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
