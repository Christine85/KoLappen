using KoLappen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    interface IEducationRepository
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
            //var allCourses = dbContext.Educations.Group Education By(
                
            //    )

            //return 

            var allCourses = 
                from Education in edu
        }
    }
}
