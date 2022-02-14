using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
