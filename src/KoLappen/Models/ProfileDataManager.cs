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
            //var user = context.Users.First();/*Single(o => o.UserName == userName);*/

            var user = context.Users
                .Where(o => o.UserName == userName)
                .Select(o => new ProfileVM
                {
                    Name = o.Firstname,
                    LastName = o.Lastname,
                    Email = idUser.Email,
                    PhoneNumber = idUser.PhoneNumber
                })
                .Single();

            //return new ProfileVM
            //{
            //    //Name = user.Firstname,
            //    //LastName = user.Lastname,
            //    //Email = idUser.Email,
            //    //PhoneNumber = idUser.PhoneNumber,
            //    Education = user.Education/*,*/
            //    //JobAreas = user.UserJobAreas
            //};
            return user;
        }
    }
}
