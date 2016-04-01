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
        Education GetEducation(int eduId);
        List<UserJobArea> GetUserJobAreas(int jobId);
        //IEnumerable<SelectListItem> GetEducations();
        //IEnumerable<SelectListItem> GetJobAreas();
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
                Education = GetEducation(viewModel.Education),
                //UserJobAreas = GetUserJobAreas(Convert.ToInt32(viewModel.JobArea)),
                UserJobAreas = null,
                NeedHelp = false,
                HelpTime = DateTime.Now,
                ProfilePic = null
            };

            userProfile.Education = new Education
            {
                EducationID = viewModel.Education
            };

            dbContext.Users.Add(userProfile);
            dbContext.SaveChanges();
        }

        public List<UserJobArea> GetUserJobAreas(int jobId)
        {
            List<UserJobArea> jobAreas = new List<UserJobArea>();
            //var jobList = dbContext.JobAreas.Select(j =>
            //new UserJobArea
            //{
            //    JobAreaID = j.JobAreaID,

            //    City = j.City,
            //    UserJobAreas = j.UserJobAreas
            //});
            //foreach (var job in jobList)
            //{
            //    jobAreas.Add(job);
            //}
            return jobAreas;
        }

        public Education GetEducation(int eduId)
        {
            Education education = new Education();
            var eduList = dbContext.Educations.Select(e =>
            new Education
            {
                EducationID = e.EducationID,
                CourseName = e.CourseName,
                Semester = e.Semester,
                Location = e.Location,
                Users = null

            });
            education = eduList.Single(e => e.EducationID == eduId);
            return education;
        }
        

        //public IEnumerable<User> GetUser(int educationId)
        //{
        //    List<User> userList = new List<User>();
        //    var usList = dbContext.Users.Select(x=>
        //    new User
        //    {
        //        UserID = x.UserID,
        //        UserName = x.UserName,
        //        Firstname = x.Firstname,
        //        Lastname = x.Lastname,
        //    })
        //}
        //public IEnumerable<SelectListItem> GetEducations()
        //{
        //    List<SelectListItem> educationsList = new List<SelectListItem>();
        //    var eduList = dbContext.Educations.Select(x =>
        //                        new SelectListItem
        //                        {
        //                            Value = x.EducationID.ToString(),
        //                            Text = x.CourseName
        //                        });
        //    return eduList;
        //}
        //public IEnumerable<SelectListItem> GetJobAreas()
        //{
        //    List<SelectListItem> educationsList = new List<SelectListItem>();
        //    var jobList = dbContext.JobAreas.Select(x =>
        //                        new SelectListItem
        //                        {
        //                            Value = x.JobAreaID.ToString(),
        //                            Text = x.City
        //                        });
        //    return jobList;
        //}
    }
}