using System.Collections.Generic;

namespace KoLappen.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<Education> Educations { get; set; }
    }
}