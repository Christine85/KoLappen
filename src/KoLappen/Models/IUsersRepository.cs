using KoLappen.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KoLappen.Models
{
    public interface IUsersRepository
    {
        void AddUser(AddUserViewModel viewModel, string userId);
        IEnumerable<SelectListItem> GetEducations();
        IEnumerable<SelectListItem> GetJobAreas();
    }

    public class DbUsersRepository : IUsersRepository
    {
        DBContext dbContext;

        public DbUsersRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddUser(AddUserViewModel viewModel, string userId)
        {
            var userProfile = new User
            {
                UserID = userId,
                UserName = viewModel.Email,
                Firstname = viewModel.Firstname,
                Lastname = viewModel.Lastname,
                EducationID = viewModel.EducationID,
                NeedHelp = false,
                HelpTime = DateTime.Now,
                ProfilePic = 1
            };

            dbContext.Users.Add(userProfile);
            dbContext.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetEducations()
        {
            List<SelectListItem> educationsList = new List<SelectListItem>();
            var eduList = dbContext.Educations.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.EducationID.ToString(),
                                    Text = x.CourseName
                                });
            return eduList;
        }
        public IEnumerable<SelectListItem> GetJobAreas()
        {
            List<SelectListItem> educationsList = new List<SelectListItem>();
            var jobList = dbContext.JobAreas.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.JobAreaID.ToString(),
                                    Text = x.City
                                });
            return jobList;
        }
    }
}
