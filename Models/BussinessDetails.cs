using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class BussinessDetails
    {
            [Key]
            public int BussinessID { get; set; }
            [Required]
            public string EmailID { get; set; }
            [Phone]
            [Required]
            public string MobileNo { get; set; }
            [Required]
            public string Subject { get; set; }
            [Required]
            public string Message { get; set; }
        }
    }