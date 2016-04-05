using Microsoft.Data.Entity;

namespace KoLappen.Models
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Consultant> Consultant { get; set; }
        public DbSet<TeacherEducation> TeacherEducation { get; set; }
        public DbSet<TeacherRole> TeacherRole { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<UserJobLocation> UserJobLocation { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users").HasKey("UserId");
            modelBuilder.Entity<Teacher>().ToTable("Teachers").HasKey("TeacherId");
            modelBuilder.Entity<Consultant>().ToTable("Consultants").HasKey("ConsultantId");
            modelBuilder.Entity<TeacherEducation>().ToTable("TeacherEducation").HasKey("TeacherEducationId");
            modelBuilder.Entity<TeacherRole>().ToTable("TeacherRoles").HasKey("TeacherRoleId");
            modelBuilder.Entity<Education>().ToTable("Educations").HasKey("EducationId");
            modelBuilder.Entity<Location>().ToTable("Locations").HasKey("LocationId");
            modelBuilder.Entity<Course>().ToTable("Courses").HasKey("CourseId");
            modelBuilder.Entity<Semester>().ToTable("Semesters").HasKey("SemesterId");
            modelBuilder.Entity<UserJobLocation>().ToTable("UserJobLocations").HasKey("UserJobLocationId");
            modelBuilder.Entity<Post>().ToTable("Posts");

            //    modelBuilder.Entity<User>()
            //        .HasOne(u => u.Education)
            //        .WithMany(e => e.Users);

            //    modelBuilder.Entity<Location>().ToTable("JobAreas").HasKey("JobAreaID");
            //    modelBuilder.Entity<Education>().ToTable("Educations").HasKey("EducationID");
            //    modelBuilder.Entity<Education>()
            //        .HasMany(e => e.Users)
            //        .WithOne(u => u.Education);
            //    modelBuilder.Entity<Semester>().ToTable("Semesters").HasKey("SemesterID");
            //    //modelBuilder.Entity<Semester>()
            //    //    .HasMany(e => e.Users)
            //    //    .WithOne(u => u.Semester);
            //    modelBuilder.Entity<AspNetRole>().ToTable("AspNetRoles").HasKey("Id");
            //    modelBuilder.Entity<UserJobArea>().ToTable("UserJobAreas").HasKey("UserJobAreaId");

            //    modelBuilder.Entity<UserJobArea>()
            //        .HasOne(uja => uja.User)
            //        .WithMany(u => u.UserJobAreas);
            //    modelBuilder.Entity<UserJobArea>()
            //        .HasOne(uja => uja.JobArea)
            //        .WithMany(ja => ja.UserJobAreas);






            //    modelBuilder.Entity<nUser>().ToTable("nUsers").HasKey("UserId");
            //    modelBuilder.Entity<nEducation>().ToTable("nEducations").HasKey("EducationId");
            //    modelBuilder.Entity<Course>().ToTable("nCourse").HasKey("CourseId");
            //    modelBuilder.Entity<nSemester>().ToTable("nSemester").HasKey("SemesterId");
            //    modelBuilder.Entity<nLocation>().ToTable("nLocation").HasKey("LocationId");


            //    modelBuilder.Entity<nUser>()
            //        .HasOne(u => u.Education)
            //        .WithMany(e => e.Users);

            //    modelBuilder.Entity<nEducation>()
            //        .HasMany(e => e.Users)
            //        .WithOne(u => u.Education);

            //    modelBuilder.Entity<nEducation>()
            //        .HasOne(u => u.Course)
            //        .WithMany(c => c.Educations);

            //    modelBuilder.Entity<nEducation>()
            //        .HasOne(u => u.Semester)
            //        .WithMany(s => s.Educations);

            //    modelBuilder.Entity<nEducation>()
            //        .HasOne(u => u.Location)
            //        .WithMany(l => l.Educations);

            //    modelBuilder.Entity<Course>()
            //        .HasMany(c => c.Educations)
            //        .WithOne(e => e.Course);

            //    modelBuilder.Entity<nSemester>()
            //        .HasMany(s => s.Educations)
            //        .WithOne(e => e.Semester);

            //    modelBuilder.Entity<nLocation>()
            //        .HasMany(l => l.Educations)
            //        .WithOne(e => e.Location);
        }
    }
}
