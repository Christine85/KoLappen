using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "E-mail")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Lösenord")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
