using KoLappen.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace KoLappen.Models
{
    public interface IAccountRepository
    {
        void CompleteUser(RegisterUserViewModel viewModel, string userId, string code);
        RegisterUserViewModel[] GetAllConsultants();
        RegisterUserViewModel GetRegistrationOptions();
        void CompleteRegistration(CompleteRegistrationViewModel model);
    }

    public class DbAccountRepository : IAccountRepository
    {
        DBContext dbContext;

        public DbAccountRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CompleteUser(RegisterUserViewModel model, string userId, string code)
        {
            var user = new User
            {
                UserId = userId,
                UserName = model.Email,
                Firstname = null,
                Lastname = null,
                ProfilePic = null,
                RegistrationComplete = false,
                ResetPasswordString = code
            };

            var consultant = new Consultant
            {
                ConsultantId = 0,
                UserId = userId,
                EducationId = model.Education,
                HelpTime = DateTime.Now
            };

            var userJobLocation = new UserJobLocation
            {
                LocationId = model.JobLocation,
                UserId = userId
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            dbContext.Consultant.Add(consultant);
            dbContext.SaveChanges();
            dbContext.UserJobLocation.Add(userJobLocation);
            dbContext.SaveChanges();
            //dbContext.Entry(user).State = EntityState.Modified;
            //dbContext.SaveChanges();
        }

        public RegisterUserViewModel[] GetAllConsultants()
        {
            var allConsultants = dbContext.Consultant.Select(c =>
            new RegisterUserViewModel
            {
                Firstname = c.User.Firstname
            }).ToArray();
            return allConsultants;
        }

        public RegisterUserViewModel GetRegistrationOptions()
        {
            var eduOptions = dbContext.Education.Select(e =>
            new SelectListItem
            {
                Value = e.EducationId.ToString(),
                Text = $"{e.Course.CourseName} {e.Semester.SemesterName} {e.Location.City}"
            });
            //new Education
            //{
            //    EducationId = e.EducationId,
            //    Course = e.Course,
            //    Semester = e.Semester,
            //    Location = e.Location
            //}).ToList();

            var locOption = dbContext.Location.Select(l =>
                        new SelectListItem
                        {
                            Value = l.LocationId.ToString(),
                            Text = $"{l.City}"
                        });
            //new Location
            //{
            //    LocationId = l.LocationId,
            //    City = l.City
            //}).ToList();

            var regOptions = new RegisterUserViewModel()
            {
                Educations = eduOptions,
                JobLocations = locOption
            };

            return regOptions;
        }

        public void CompleteRegistration(CompleteRegistrationViewModel model)
        {
            var user = dbContext.Users
                .Where(u => u.UserName == model.Email)
                .Select(u =>
                new User
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    Firstname=model.Firstname,
                    Lastname = model.Lastname,
                    ProfilePic = u.ProfilePic,
                    //RegistrationComplete = true ,
                    //ResetPasswordString = null                   
                }).First();
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}