using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        //public string UserId { get; set; }
        //public User User { get; set; }
        public int CourseId { get; set; }
        public int TeacherEducationId { get; set; }
        public int TeacherRoleId { get; set; }
    }
}
