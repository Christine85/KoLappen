using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class FormToQuestion
    {
        public Form Form { get; set; }
        public FormQuestion FormQuestion { get; set; }
        public int FormId { get; set; }
        public int QuestionId { get; set; }
    }
}
