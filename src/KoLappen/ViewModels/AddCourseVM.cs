using KoLappen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class AddCourseVM
    {        
        //public Education Education { get; set; }

        [Display(Name = "Kurs namn")]
        [Required]
        public string CourseName { get; set; }

        [Display(Name = "Termin")]
        [Required]
        public string Semester { get; set; }

        [Display(Name = "Plats")]
        [Required]
        public string Location { get; set; }
    }
}
