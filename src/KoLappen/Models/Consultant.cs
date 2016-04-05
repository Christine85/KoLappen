using System;
using System.Collections.Generic;

namespace KoLappen.Models
{
    public class Consultant
    {
        public int ConsultantId { get; set; }
        public string UserId { get; set; }
        public int EducationId { get; set; }
        public List<UserJobLocation> UserJobLocation { get; set; }
        public bool NeedHelp { get; set; }
        public DateTime HelpTime { get; set; }
    }
}
