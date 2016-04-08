using KoLappen.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Linq;

namespace KoLappen.Models
{
    public interface IEducationRepository
    {
        AlumnerVM[] GetAllCourses();
        void AddEducation(AddEducationVM viewModel);
        AlumnerVM[] GetAllSemesters(int courseId);
        AddEducationVM GetRegisterEducationOptions();
        void AddLocation(AddEducationVM viewModel);
        void AddSemester(AddEducationVM viewModel);
        void AddCourse(AddEducationVM viewModel);
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

        public void AddEducation(AddEducationVM model)
        {
            AddEducationVM acVM = GetRegisterEducationOptions();

            Education education = new Education();
            education.LocationId = Convert.ToInt32(model.LocationName); // model.Location;
            education.SemesterId = Convert.ToInt32(model.SemesterName);
            education.CourseId = Convert.ToInt32(model.CourseName);

            education.StartDate = DateTime.Now.AddDays(-2);
            education.EndDate = DateTime.Now.AddDays(2);

            dbContext.Education.Add(education);
            dbContext.SaveChanges();
            //    dbContext.Education.Add(new Education
            //    {

            //        //CourseName = model.CourseName,
            //        //education.Semester.SemesterName = model.Semester,
            //        //education.Location.City = model.Location,

            //        //education.startDate = DateTime.Now,
            //        //education.endDate = DateTime.Now.AddDays(7);

            //    //dbContext.Education.Add(education);
            //});
            //dbContext.SaveChanges();
            //var course = dbContext.Course
            //    .FirstOrDefault(c => c.CourseName == model.CourseName);

            ////var course = new Course();
            ////var semester = new Semester();
            ////var location = new Location();

            //course.CourseName = model.CourseName;
            ////course.Semester = model.Semester;
            ////course.Location = model.Location;

            //course.CourseName = model.CourseName;
            //semester.SemesterName = model.Semester;
            //location.City = model.Location;

            //education.startDate = DateTime.Now;
            //education.endDate = DateTime.Now.AddDays(7);


            ////education.Course = course;
            ////education.SemesterId = 1;
            ////education.LocationId = 1;
            //education.CourseId = 1;
            //course.Educations.Add(education);

            //location.Education.Add(education);
            //semester.Education.Add(education);
            //dbContext.Course.Add(course);


        }

        public AddEducationVM GetRegisterEducationOptions()
        {
            //Sätt kurser i en drodown list            
            var courseOptions = dbContext.Course.Select(e =>
                new SelectListItem
                {
                    Value = e.CourseId.ToString(),
                    Text = $"{e.CourseName}"
                });

            //Sätt terminer i en drodown list            
            var semOptions = dbContext.Semester.Select(e =>
                new SelectListItem
                {
                    Value = e.SemesterId.ToString(),
                    Text = $"{e.SemesterName}"
                });

            //Sätt städer i en dropdown list                    
            var locOption = dbContext.Location.Select(l =>
                new SelectListItem
                {
                    Value = l.LocationId.ToString(),
                    Text = $"{l.City}"
                });

            //Sätt de nya listorna till vy modellen
            var regOptions = new AddEducationVM()
            {
                Courses = courseOptions,
                Semesters = semOptions,
                Locations = locOption
            };


            return regOptions;
        }
        public void AddCourse(AddEducationVM model)
        {
            Course course = new Course()
            {
                CourseName = model.CourseName
            };

            dbContext.Course.Add(course);
            dbContext.SaveChanges();
        }
        public void AddSemester(AddEducationVM model)
        {
            Semester semester = new Semester()
            {
                SemesterName = model.SemesterName
            };

            dbContext.Semester.Add(semester);
            dbContext.SaveChanges();
        }
        public void AddLocation(AddEducationVM model)
        {
            Location location = new Location()
            {
                City = model.LocationName
            };

            dbContext.Location.Add(location);
            dbContext.SaveChanges();
        }
    }
}