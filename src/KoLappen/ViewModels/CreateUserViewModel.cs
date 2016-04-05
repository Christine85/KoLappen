﻿using KoLappen.Models;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Fyll i förnamn.")]
        [Display(Name = "Förnamn")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Fyll i efternamn.")]
        [Display(Name = "Efternamn")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Fyll i utbildnings id nummer.")]
        [Display(Name = "Utbildnings ID")]
        public int Education { get; set; }
        public IEnumerable<SelectListItem> Educations { get; set; }

        [Required(ErrorMessage = "Fyll i jobbområde.")]
        [Display(Name = "Jobbområde")]
        public int JobArea { get; set; }
        public IEnumerable<SelectListItem> JobAreas  { get; set; }


        [Required(ErrorMessage = "Fyll i din email.")]
        [EmailAddress(ErrorMessage = "Ogiltig e-mail adress")]
        [Display(Name = "E-mail adress")]
        public string Email { get; set; }
    }
}