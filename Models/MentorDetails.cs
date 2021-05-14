using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class MentorDetails
    {
            [Key]
            public int MentorID { get; set; }
            [Required]
            public string EmailID { get; set; }
            [Phone]
            public string MobileNo { get; set; }
            public string Qualification { get; set; }
            [Required]
            public string Attendance { get; set; }
            [Required]
            public string Resume { get; set; }
        }
    }