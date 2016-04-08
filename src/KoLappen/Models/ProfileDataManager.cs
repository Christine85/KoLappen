using KoLappen.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
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

        public async Task<int> EditProfile(EditProfileVM model)
        {
            var user = await context.Users.SingleAsync(o => o.UserName == model.UserId);
            user.Firstname = model.Firstname;
            user.Lastname = model.Lastname;
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var aspNetUser = await aspNetUserCon.FindByNameAsync(model.UserId);
            aspNetUser.Email = model.Email;
            aspNetUser.PhoneNumber = model.Phonenumber;
            await aspNetUserCon.UpdateAsync(aspNetUser);
            return await identityContext.SaveChangesAsync();
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
                    SemesterName = o.Education.Semester.SemesterName,
                    Image = o.User.ProfilePic

                })
                .SingleOrDefault();

            consultant.UserJobLocation = GetLocations(idUser);

            return consultant;
        }

        private Location[] GetLocations(IdentityUser idUser)
        {
            return context.UserJobLocation
                .Where(o => o.UserId == idUser.Id)
                .Select(o => new Location
                {
                    City = o.Location.City,
                    Education = null,
                    LocationId = 0
                })
                .ToArray();
        }

        public List<ProfileVM> GetOneClass(int semesterId, int courseId)
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

        public EditProfileVM GetProfileToEdit(string userName)
        {
            var aspNetUser = aspNetUserCon.Users.Single(o => o.UserName == userName);
            var user = context.Users.Where(o => o.UserName == userName)
                .Select(o => new EditProfileVM
                {
                    Firstname = o.Firstname,
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
