using System;
using System.Collections.Generic;

namespace KoLappen.Models
{
    public class Consultant
    {
        public int ConsultantId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        //asjklklsjf
        public int EducationId { get; set; }
        public Education Education { get; set; }
        public bool NeedHelp { get; set; }
        public DateTime HelpTime { get; set; }
    }
}
