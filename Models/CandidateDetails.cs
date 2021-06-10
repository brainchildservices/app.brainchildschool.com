using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class CandidateDetails
    {
        [Key]
        public int CandidateID { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Phone]
        [Required]
        public string MobileNo { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public EducationLevel EducationLevel { get; set; }
        public Shedule Shedule { get; set; }
        [Required]
        public string Attendance { get; set; }
        public string Message { get; set; }
    }
}
