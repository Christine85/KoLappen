using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoLappen.ViewModels;

namespace KoLappen.Models
{
    public class TestProfileDM : IProfileRepository
    {
        static List<User> users = new List<User>();
        static List<Education> educations = new List<Education>();
        static List<JobArea> jobAeas = new List<JobArea>();
        static List<UserJobArea> userJobAreas = new List<UserJobArea>();
        IdentityDbContext iContext;

        static TestProfileDM()
        {
            users.Add(new User
            {
                UserID = "79676dad-bc6c-40fb-8d62-3caa6c295a6e",
                UserName = "Christine",
                Firstname = "Christine",
                Lastname = "G",
                NeedHelp = false,
                EducationID = 2,
                Education = null,
                UserJobAreas = null,
                HelpTime = DateTime.Now,
                ProfilePic = null
            });

            educations.Add(new Education
            {
                CourseName = "C#.net",
                EducationID = 1,
                Location = "Stockholm",
                Semester = "HT 2015",
                Users = null
            });

            educations.Add(new Education
            {
                CourseName = "C#.net",
                EducationID = 2,
                Location = "Stockholm",
                Semester = "VT 2016",
                Users = null
            });

            jobAeas.Add(new JobArea
            {
                City = "Stockholm",
                JobAreaID = 1,
                UserJobAreas = null
            });

            jobAeas.Add(new JobArea
            {
                City = "Göteborg",
                JobAreaID = 2,
                UserJobAreas = null
            });

            userJobAreas.Add(new UserJobArea
            {
                UserJobAreaId = 1,
                JobAreaID = 1,
                JobArea = null,
                UserID = "79676dad-bc6c-40fb-8d62-3caa6c295a6e",
                User = null
            });
        }
        public TestProfileDM(IdentityDbContext iContext)
        {
            this.iContext = iContext;
        }

        public ProfileVM GetProfile(string userName)
        {
            var iUser = iContext.Users.Single(o => o.UserName == userName);
            return users.Where(o => o.UserName == userName)
                .Select(o => new ProfileVM
                {
                    Name = o.Firstname,
                    LastName = o.Lastname,
                    Email = iUser.Email,
                    PhoneNumber = iUser.PhoneNumber,
                    Education = educations.Where(e => e.EducationID == o.EducationID).Select(e => new Education
                    {
                        CourseName = e.CourseName,
                        EducationID = e.EducationID,
                        Location = e.Location,
                        Semester = e.Semester,
                        Users = null
                    })
                    .Single()
                })
                .Single();
        }
    }
}
