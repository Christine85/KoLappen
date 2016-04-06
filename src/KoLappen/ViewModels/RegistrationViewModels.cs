using KoLappen.Models;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class MultiRegisterViewModel
    {
        [Required(ErrorMessage = "Fyll i din email.")]
        [EmailAddress(ErrorMessage = "Ogiltig e-mail adress")]
        [Display(Name = "E-mail adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Välj utbildning.")]
        [Display(Name = "Utbildnings ID")]
        public int Education { get; set; }
        public IEnumerable<SelectListItem> Educations { get; set; }

        [Required(ErrorMessage = "Välj jobbområde.")]
        [Display(Name = "Jobbområde")]
        public int JobLocation { get; set; }
        public IEnumerable<SelectListItem> JobLocations { get; set; }
    }
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Fyll i din email.")]
        [EmailAddress(ErrorMessage = "Ogiltig e-mail adress")]
        [Display(Name = "E-mail adress")]
        public string Email { get; set; }

        [Display(Name = "Förnamn (Valfritt)")]
        public string Firstname { get; set; }

        [Display(Name = "Efternamn (Valfritt)")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Välj utbildning.")]
        [Display(Name = "Utbildnings ID")]
        public int Education { get; set; }
        public IEnumerable<SelectListItem> Educations { get; set; }

        [Required(ErrorMessage = "Välj jobbområde.")]
        [Display(Name = "Jobbområde")]
        public int JobLocation { get; set; }
        public IEnumerable<SelectListItem> JobLocations { get; set; }
    }

    public class CompleteRegistrationViewModel
    {
        [Required(ErrorMessage = "Fyll i din email.")]
        [EmailAddress(ErrorMessage = "Ogiltig e-mail adress")]
        [Display(Name = "E-mail adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fyll i förnamn.")]
        [StringLength(50, ErrorMessage = "{0} måste minst vara {2} tecken långt.", MinimumLength = 2)]
        [Display(Name = "Förnamn")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Fyll i efternamn.")]
        [StringLength(50, ErrorMessage = "{0} måste minst vara {2} tecken långt.", MinimumLength = 2)]
        [Display(Name = "Efternamn")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Fyll i NYTT lösenord.")]
        [DataType(DataType.Password)]
        [Display(Name = "Nytt lösenord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta nytt lösenord")]
        [Compare("Password", ErrorMessage = "'Nytt lösenord' och 'Bekräfta nytt lösenord' måste matcha.")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Lösenordet måste vara mellan 8 och 32 tecken långt.")]
        [RegularExpression(@"^(?=.*\d).{8,32}$", ErrorMessage = "Lösenordet måste innehålla minst en bokstav och minst en siffra.")] // "^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Fyll i verifikations lösenordet.")]
        [DataType(DataType.Password)]
        [Display(Name = "Verifikations lösenord")]
        public string VerificationPassword { get; set; }
    }
}
