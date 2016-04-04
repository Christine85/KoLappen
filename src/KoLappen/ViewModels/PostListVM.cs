using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class PostListVM
    {
        public string PostText { get; set; }
        public string Link { get; set; }
        public string PostedByFirstname { get; set; }
        public string PostedByLastname { get; set; }
        public DateTime TimePosted { get; set; }
    }
}
