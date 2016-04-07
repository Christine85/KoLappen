using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class AddAdminPostVM
    {
        [Display(Name = "Text")]
        [Required(ErrorMessage = "Skriv in text som skall publiceras.")]
        public string PostText { get; set; }

        [Display(Name = "Länk")]
        public string Link { get; set; }

        public DateTime TimePosted { get; set; }
    }
}
