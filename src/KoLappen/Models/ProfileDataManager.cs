using KoLappen.ViewModels;
using Microsoft.AspNet.Identity;
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
        UserManager<IdentityUser> aspNetUserCon;

        public ProfileDataManager(DBContext context,
            IdentityDbContext identityContext,
            UserManager<IdentityUser> aspNetUserCon)
        {
            this.context = context;
            this.identityContext = identityContext;
            this.aspNetUserCon = aspNetUserCon;
        }

        public void EditProfile(EditProfileVM model)
        {
            var aspNetUser = aspNetUserCon.Users
                .Where(o=>o.UserName== model.UserId)
                .Single();

            var user = context.Users
                .Where(o=>o.UserName == model.UserId)
                .Single();
            user.Firstname = model.Firstname;
            user.Lastname = model.Lastname;
            aspNetUser.Email = model.Email;
            aspNetUser.PhoneNumber = model.Phonenumber;

            context.SaveChanges();

        }

        public ProfileVM GetProfile(string userName)
        {
            var idUser = identityContext.Users.Single(o => o.UserName == userName);
            var consultant = context.Users
                .Where(o => o.UserName == userName)
                .Select(o => new ProfileVM
                {
                    Name = o.Firstname,
                    LastName = o.Lastname,
                    //Email = idUser.Email,
                    //PhoneNumber = idUser.PhoneNumber,
                    //EducationName = o.Course.CourseName,
                    //SemesterName = o.Education.Semester.SemesterName,
                    //Image = o.User.ProfilePic,
                    //UserJobLocation = o.User.UserJobLocations.Select(l=>l.Location).ToArray()

                })
                .SingleOrDefault();

            //var locations = context.UserJobLocation
            //    .Where(o => o.UserId == idUser.Id)
            //    .Select(o => new Location
            //    {
            //        City = o.Location.City,
            //        Education = null,
            //        LocationId = 0
            //    })
            //    .ToArray();

            //consultant.UserJobLocation = locations;

            return consultant;
            //return new ProfileVM
            //{
            //    Name = consultant.User.Firstname,
            //    LastName = consultant.User.Lastname,
            //    Email = idUser.Email,
            //    PhoneNumber = idUser.PhoneNumber 
            //};
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
                    //Education = item.Education
                })
                .ToList());
            }

            return selectedClass;
        }

        public EditProfileVM GetProfileToEdit(string userName)
        {
            var aspNetUser = aspNetUserCon.Users.Single(o => o.UserName == userName);
            var user = context.Users.Where(o => o.UserName == userName)
                .Select(o => new EditProfileVM
                {
                    Firstname = o.UserName,
                    Lastname = o.Lastname,
                    Email = aspNetUser.Email,
                    Phonenumber = aspNetUser.PhoneNumber,
                    UserId = o.UserId
                })
                .Single();

            return user;
        }
    }
}
