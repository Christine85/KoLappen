using KoLappen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public interface IEducationRepository
    {
        EducationVM[] GetAllCourses();
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
            return dbContext.Educations
                .Select(o => new EducationVM
                {
                    CourseName = o.CourseName,
                    Semester = o.Semester,
                    EducationID = o.EducationID
                })
                .ToArray();
        }
    }
}
