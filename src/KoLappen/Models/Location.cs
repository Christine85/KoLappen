using System.Collections.Generic;

namespace KoLappen.Models
{
    public class Location
    {
        public Location()
        {
            Education = new List<Education>();
        }
        public int LocationId { get; set; }
        public string City { get; set; }
        public List<Education> Education { get; set; }
    }
}