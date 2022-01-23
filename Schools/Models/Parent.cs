using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
