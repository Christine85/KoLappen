using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class AddPostVM
    {
        [Display(Name = "Text")]
        [Required(ErrorMessage = "Skriv in text som skall publiceras.")]
        public string PostText { get; set; }

        [Display(Name = "Länk")]
        public string Link { get; set; }

        // behövs????
        public DateTime TimePosted { get; set; }
        

        //[Display(Name = "Färg")]
        //[Required(ErrorMessage = "Ange en färg.")]
        //public string Color { get; set; }

        //[Display(Name = "Årsmodell")]
        //[Range(1900, 2016, ErrorMessage = "Årsmodell 1900 - nuvarande år.")]
        //[Required(ErrorMessage = "Ange vilken årsmodell det är.")]
        //public int Year { get; set; }


    }
}
