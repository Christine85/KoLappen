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
            var user = context.Users.SingleOrDefault(o => o.UserName == userName);
                //.Where(o => o.UserName == userName)
                //.Select(o => new ProfileVM
                //{
                //    Name = o.Firstname,
                //    LastName = o.Lastname,
                //    Email = idUser.Email,
                //    PhoneNumber = idUser.PhoneNumber,
                //    Education = o.Education
                //})
                //.Single();
            return new ProfileVM
            {
                Name = user.Firstname,
                LastName = user.Lastname,
                Email = idUser.Email,
                PhoneNumber = idUser.PhoneNumber,
                //Education = user.Education
            };
        }
        
        public List<ProfileVM> GetOneClass(int edu)
        {
            var idUser = identityContext.Users.ToList();
            var u = context.Users;
            var users = context.Users
                //.Where(o => o.Education.EducationID == edu)
                .Select(o => new ProfileVM
                {
                    UserName = o.UserName,
                    Name = o.Firstname,
                    LastName = o.Lastname,

                    //Education = o.Education
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
