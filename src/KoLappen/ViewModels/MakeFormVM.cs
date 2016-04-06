using KoLappen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class MakeFormVM
    {        
        public string CourseName { get; set; }
        public string SemesterName { get; set; }
        public int EducationWeek { get; set; }        
        public string Question { get; set; }
        public List<FormOption> FormOption { get; set; }
    }
}
