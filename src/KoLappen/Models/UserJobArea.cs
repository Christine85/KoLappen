using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class UserJobArea
    {
        public int UserJobAreaId { get; set; }
        //public int JobAreaID { get; set; }
        //public string UserID { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }

        public int JobAreaID { get; set; }
        public JobArea JobArea { get; set; }
    }
}
