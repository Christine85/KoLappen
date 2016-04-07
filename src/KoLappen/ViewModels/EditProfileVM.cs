using System.ComponentModel.DataAnnotations;

namespace KoLappen.ViewModels
{
    public class EditProfileVM
    {
        [Display(Name ="Förnamn")]
        public string Firstname { get; set; }
        [Display(Name ="Efternamn")]
        public string Lastname { get; set; }
        [Display(Name ="E-mail")]
        public string Email { get; set; }
        [Display(Name ="Telefonnummer")]
        public string Phonenumber { get; set; }
        public string UserId { get; set; }
    }
}