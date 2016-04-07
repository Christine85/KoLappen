using KoLappen.Models;
using Microsoft.AspNet.Mvc.Rendering;
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
        public IEnumerable<SelectListItem> CourseNames { get; set; }

        [Display(Name = "Termin")]
        [Required]
        public string Semester { get; set; }
        public IEnumerable<SelectListItem> Semesters { get; set; }

        [Display(Name = "Plats")]
        [Required]
        public string Location { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
    }
}
