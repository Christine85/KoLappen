using KoLappen.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
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
        List<UserJobArea> GetUserJobAreas(int jobId, string userId);
        //IEnumerable<SelectListItem> GetEducations();
        //IEnumerable<SelectListItem> GetJobAreas();
        void AddCourse(AddCourseVM viewModel);
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
                //UserJobAreas = GetUserJobAreas(viewModel.JobArea, userId),
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

            var userJobAreas = GetUserJobAreas(viewModel.JobArea, userId);

            userProfile.UserJobAreas = userJobAreas;
            dbContext.Entry(userProfile).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public List<UserJobArea> GetUserJobAreas(int jobId, string userId)
        {
            List<UserJobArea> jobAreas = new List<UserJobArea>();
            var userJobArea = new UserJobArea
            {
                UserID = userId,
                JobAreaID = jobId
            };

            jobAreas.Add(userJobArea);
            dbContext.UserJobAreas.Add(userJobArea);
            dbContext.SaveChanges();

            return jobAreas;

            //List<UserJobArea> jobAreas = new List<UserJobArea>();
            //jobAreas.Add(new UserJobArea { UserID = userId, JobAreaID = jobId})
            //var jobList = dbContext.UserJobAreas.Select(j =>
            //new UserJobArea
            //{
            //    UserJobAreaId = j.JobAreaID,
            //    UserID = j.UserID,
            //    JobAreaID = j.UserJobAreaId
            //});
            //foreach (var job in jobList)
            //{
            //    jobAreas.Add(job);
            ////}
            //return jobAreas;
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

        public void AddCourse(AddCourseVM viewModel)
        {
            var course = new Education();

            course.CourseName = viewModel.CourseName;
            course.Semester = viewModel.Semester;
            course.Location = viewModel.Location;

            dbContext.Educations.Add(course);
            dbContext.SaveChanges();
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