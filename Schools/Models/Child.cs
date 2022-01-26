using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models
{
    public class Child
    {
        [Key]
        public int id { get; set; }
        public int parent_id { get; set; }
        public int school_id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
