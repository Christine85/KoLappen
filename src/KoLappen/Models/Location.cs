using System.Collections.Generic;

namespace KoLappen.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string City { get; set; }
        public List<Education> Education { get; set; }
    }
}