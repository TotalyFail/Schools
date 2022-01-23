using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
