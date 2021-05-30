using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class QuickCandidateForm
    {       
        
        public string EmailID { get; set; }        
        
        public string MobileNo { get; set; }        
        public string Name { get; set; }
    }
}
