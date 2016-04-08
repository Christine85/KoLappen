using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KoLappen.ViewModels
{
    public class AddEducationVM
    {        
        //public Education Education { get; set; }

        [Display(Name = "Kurs")]
        [Required]
        public string CourseName { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; }

        [Display(Name = "Termin")]
        [Required]
        public string SemesterName { get; set; }
        public IEnumerable<SelectListItem> Semesters { get; set; }

        [Display(Name = "Stad")]
        [Required]
        public string LocationName { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
    }

    //public class AddCourseVM
    //{
    //    [Display(Name = "Kurs namn")]
    //    [Required]
    //    public string CourseName { get; set; }
    //}
    //public class AddSeesterVM
    //{
    //    [Display(Name = "Termin")]
    //    [Required]
    //    public string SemesterName { get; set; }
    //}
    //public class AddEducAddLocationVMationVM
    //{
    //    [Display(Name = "Plats")]
    //    [Required]
    //    public string LocationName { get; set; }
    //}
}
