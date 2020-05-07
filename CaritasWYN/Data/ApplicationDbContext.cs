using System;
using System.Collections.Generic;
using System.Text;
using CaritasWYN.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CaritasWYN.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Act_type> Act_Types { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<DailyActivity> DailyActivities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<JobDuty> JobDuties { get; set; }
        public DbSet<Referrer> Referrers { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.Entity<Act_type>().ToTable("Act_type");
            //modelBuilder.Entity<Client>().ToTable("Client");
            //modelBuilder.Entity<DailyActivity>().ToTable("DailyActivity");
            //modelBuilder.Entity<Group>().ToTable("Group");
            //modelBuilder.Entity<JobDuty>().ToTable("JobDuty");
            //modelBuilder.Entity<Referrer>().ToTable("Referrer");
            //modelBuilder.Entity<Staff>().ToTable("Staff");
            base.OnModelCreating(modelBuilder);
        }
    }
}
