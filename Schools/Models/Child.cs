using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models
{
    public class Child
    {
        [Key]
        public int Id { get; set; }
        public int Parent_Id { get; set; }
        public int School_Id { get; set; }
    }
}
