using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class User
    {        
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        //public Education Education { get; set; }

        public int Education { get; set; }

        public List<UserJobArea> UserJobAreas { get; set; }
        public bool NeedHelp { get; set; }
        public DateTime HelpTime { get; set; }
        public byte[] ProfilePic { get; set; }
    }
}
