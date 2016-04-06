using KoLappen.ViewModels;
using System;
using System.Linq;

namespace KoLappen.Models
{
    public interface IEducationRepository
    {
        AlumnerVM[] GetAllCourses();
        void AddCourse(AddCourseVM viewModel);
        AlumnerVM[] GetAllSemesters(int courseId);
    }

    public class DbEducationRepository : IEducationRepository
    {
        DBContext dbContext;

        public DbEducationRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public AlumnerVM[] GetAllCourses()
        {
            return dbContext.Course
                .Select(o => new AlumnerVM
                {
                    CourseName = o.CourseName,
                    //Semester = o.Semester,
                    CourseID = o.CourseId
                })
                .ToArray();
        }

        public AlumnerVM[] GetAllSemesters(int courseID)
        {
            return dbContext.Education
                .Where(i => i.CourseId == courseID)
                .Select(o => new AlumnerVM
                {                    
                    Semester = o.Semester.SemesterName,
                    CourseID = courseID,
                    SemesterId = o.SemesterId
                })
                .ToArray();
        }

        public void AddCourse(AddCourseVM model)
        {
            var education = new Education();
            //var course = dbContext.Course
            //    .FirstOrDefault(c => c.CourseName == model.CourseName);

            var course = new Course();
            var semester = new Semester();
            var location = new Location();

            //course.CourseName = model.CourseName;
            ////course.Semester = model.Semester;
            ////course.Location = model.Location;

            //course.CourseName = model.CourseName;
            //semester.SemesterName = model.Semester;
            //location.City = model.Location;

            //education.startDate = DateTime.Now;
            //education.endDate = DateTime.Now.AddDays(7);

            education.Course = course;
            education.SemesterId = 1;
            education.LocationId = 1;
            //education.CourseId = 1;
            //course.Educations.Add(education);
          
            //location.Education.Add(education);
            //semester.Education.Add(education);
            //dbContext.Course.Add(course);
                
            dbContext.Education.Add(education);
            dbContext.SaveChanges();
        }
    }
}