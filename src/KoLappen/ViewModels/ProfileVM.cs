using KoLappen.Models;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class ProfileVM
    {
        [Display(Name = "Förnamn")] 
        public string Name { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public virtual Location[] UserJobLocation { get; set; }
        public string EducationName { get; set; }
        public string SemesterName { get; set; }
        //public int Education { get; set; }

        public string UserName { get; set; }



        //[Display(Name = "Profilbild")]
        //[DataType(DataType.Upload)]
        //public IFormFile File { get; set; }
    }
}
