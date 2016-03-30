using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class JobArea
    {
        [Key]
        public int JobAreaID { get; set; }
        public string City { get; set; }
    }
}
