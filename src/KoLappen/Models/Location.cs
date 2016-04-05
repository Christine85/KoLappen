using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class Location
    {
        public int LocationIs { get; set; }
        public string City { get; set; }
        public List<Education> Education { get; set; }
    }
}
