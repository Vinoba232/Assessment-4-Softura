using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProfileDetailsAssessment.Models
{
    public class ProfileContext:DbContext
    {
        public ProfileContext()
        {

        }
        public ProfileContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Profile> Profiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(
                new Profile() { Name = "Arjunan", Age=25, Qualification="Archery",IsEmployed=true,
                    NoticePeriod= "Immediate",CurrentCTC="6 lakh"});
        }
    }
}
