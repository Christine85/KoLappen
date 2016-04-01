using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<JobArea> JobAreas { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<UserJobArea> UserJobAreas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users").HasKey("UserID");
            modelBuilder.Entity<JobArea>().ToTable("JobAreas").HasKey("JobAreaID");
            modelBuilder.Entity<Education>().ToTable("Educations").HasKey("EducationID");
            modelBuilder.Entity<AspNetRole>().ToTable("AspNetRoles").HasKey("Id");
            modelBuilder.Entity<UserJobArea>().ToTable("UserJobAreas").HasKey("UserJobAreaId");

            modelBuilder.Entity<UserJobArea>()
                .HasOne(uja => uja.User)
                .WithMany(u => u.UserJobAreas)
                .HasForeignKey(uja => uja.UserID);
            modelBuilder.Entity<UserJobArea>()
                .HasOne(uja => uja.JobArea)
                .WithMany(ja => ja.UserJobAreas)
                .HasForeignKey(uja => uja.JobAreaID);


        }
    }
}
