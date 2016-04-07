using System.Collections.Generic;

namespace KoLappen.Models
{
    public class Semester
    {
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public List<Education> Education { get; set; }
    }
}