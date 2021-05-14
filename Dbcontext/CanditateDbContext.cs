using Microsoft.EntityFrameworkCore;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Dbcontext
{
    public class CanditateDbContext : DbContext
    {
        public CanditateDbContext(DbContextOptions<CanditateDbContext> options) : base(options)
        {

        }
        public DbSet<CandidateDetails> CandidateDetails { get; set; }
        public DbSet<EducationLevel> EducationLevel { get; set; }
        public DbSet<BussinessDetails> BussinessDetails { get; set; }
        public DbSet<MentorDetails> MentorDetails { get; set; }
    }
}
