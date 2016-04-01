using KoLappen.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class ProfileDataManager
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
            var user = context.Users.Single(o => o.UserName == userName);
            return new ProfileVM
            {
                Name = user.Firstname,
                LastName = user.Lastname,
                Email = idUser.Email,
                PhoneNumber = idUser.PhoneNumber,
                //Education = user.Education/*,*/
                //JobAreas = user.UserJobAreas
            };
        }
        
        public List<ProfileVM> GetOneClass(int edu)
        {

            var user = context.Users
                .Where(o => o.Education.EducationID == edu)
                .Select(o => new ProfileVM
                {
                    UserName = o.UserName,
                    Name = o.Firstname,
                    LastName = o.Lastname,
                    Education = o.Education
                })
                .ToList();                


            var selectedClass = new List<ProfileVM>();

            foreach (var item in user)
            {
                selectedClass.AddRange(identityContext.Users
                .Where(i => i.UserName == item.UserName)
                .Select(i => new ProfileVM
                {
                    Name = item.Name,
                    LastName = item.LastName,
                    UserName = i.UserName,
                    Email = i.Email,
                    PhoneNumber = i.PhoneNumber,
                    Education = item.Education
                })
                .ToList());
            }

            return selectedClass;            
        }
        
    }
}
