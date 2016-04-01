using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class Education
    {
        public Education()
        {
            Users = new List<User>();
        }
        public int EducationID { get; set; }
        public string CourseName { get; set; }
        public string Semester { get; set; }
        public string Location { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
