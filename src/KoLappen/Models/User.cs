using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ProfilePic { get; set; }
        public bool RegistrationComplete { get; set; }
        public string ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
