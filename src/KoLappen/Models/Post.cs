﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string PostText { get; set; }
        public string Link { get; set; }
        //public string PostedByFirstName { get; set; }
        //public string PostedByLastName { get; set; }
        public DateTime TimePosted { get; set; }
        public string UserID { get; set; }
        public virtual User User { get; set; }
    }
}
