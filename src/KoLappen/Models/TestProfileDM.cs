using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                Lastname = ""
            });
        }
        public TestProfileDM(IdentityDbContext iContext)
        {
            this.iContext = iContext;
        }
    }
}
