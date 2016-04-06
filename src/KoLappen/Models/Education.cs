using System;

namespace KoLappen.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}