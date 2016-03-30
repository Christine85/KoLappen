using KoLappen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class ProfileVM
    {
        public string Name { get; set; }
        public string Efternamn { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public JobArea[] MyProperty { get; set; }
    }
}
