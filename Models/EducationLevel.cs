using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class EducationLevel
    {
        [Key]
        public int TypeId { get; set; }
        [Required]
        public string EducationType { get; set; }
    }
}
