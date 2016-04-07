﻿using KoLappen.ViewModels;
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
            var course = new Education();

            //course.CourseName = model.CourseName;
            //course.Semester = model.Semester;
            //course.Location = model.Location;

            dbContext.Education.Add(course);
            dbContext.SaveChanges();
        }
    }
}