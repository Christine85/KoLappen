using KoLappen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class EducationVM
    {
        public Education Education { get; set; }

        public string CourseName { get; set; }

        public string Semester { get; set; }

        public int EducationID { get; set; }

    }
}
