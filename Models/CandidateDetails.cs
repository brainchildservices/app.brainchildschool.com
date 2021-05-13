using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class CandidateDetails
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }
        public QualificationType Qualification { get; set; }
        public string Schedule { get; set; }
        public string Attendance { get; set; }
        public string Message { get; set; }

    }
}
