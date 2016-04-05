using KoLappen.ViewModels;
using System.Linq;

namespace KoLappen.Models
{
    public interface IEducationRepository
    {
        EducationVM[] GetAllCourses();
        void AddCourse(AddCourseVM viewModel);
    }

    public class DbEducationRepository : IEducationRepository
    {
        DBContext dbContext;

        public DbEducationRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public EducationVM[] GetAllCourses()
        {
            return dbContext.Education
                .Select(o => new EducationVM
                {
                    //CourseName = o.CourseName,
                    //Semester = o.Semester,
                    //EducationID = o.EducationID
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