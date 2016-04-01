using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class Education
    {
        public int EducationID { get; set; }
        public string CourseName { get; set; }
        public string Semester { get; set; }
        public string Location { get; set; }
        public List<User> Users { get; set; }
    }
}
