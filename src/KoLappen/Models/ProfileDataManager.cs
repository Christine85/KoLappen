using KoLappen.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class ProfileDataManager : IProfileRepository
    {
        DBContext context;
        IdentityDbContext identityContext;

        public ProfileDataManager(DBContext context,
            IdentityDbContext identityContext)
        {
            this.context = context;
            this.identityContext = identityContext;
        }

        public ProfileVM GetProfile(string userName)
        {
            var idUser = identityContext.Users.Single(o => o.UserName == userName);
            var consultant = context.Consultant

                .Where(o => o.User.UserName == userName)
                .Select(o => new ProfileVM
            {
                    Name = o.User.Firstname,
                    LastName = o.User.Lastname,
                    Email = idUser.Email,
                    PhoneNumber = idUser.PhoneNumber,
                    EducationName = o.Education.Course.CourseName,
                    SemesterName = o.Education.Semester.SemesterName 
                })
                .SingleOrDefault();

            return consultant;
            //return new ProfileVM
            //{
            //    Name = consultant.User.Firstname,
            //    LastName = consultant.User.Lastname,
            //    Email = idUser.Email,
            //    PhoneNumber = idUser.PhoneNumber 
            //};
        }
        
        public List<ProfileVM> GetOneClass(int courseId, int semesterId)
        {
            var idUser = identityContext.Users.ToList();
            
            var users = context.Consultant
                .Where(o => o.Education.CourseId == courseId && o.Education.SemesterId == semesterId)
                .Select(o => new ProfileVM
                {
                    UserName = o.User.UserName,
                    Name = o.User.Firstname,
                    LastName = o.User.Lastname,
                    Image = o.User.ProfilePic
                })
                .ToList();


            var selectedClass = new List<ProfileVM>();

            foreach (var item in users)
            {
                selectedClass.AddRange(identityContext.Users
                .Where(i => i.UserName == item.UserName)
                .Select(i => new ProfileVM
                {               
                    Name = item.Name,
                    LastName = item.LastName,                    
                    Email = i.Email,
                    PhoneNumber = i.PhoneNumber,
                    Image = item.Image,
                    UserJobLocation = item.UserJobLocation                    
                })
                .ToList());
            }

            return selectedClass;            
        }        
    }
}
