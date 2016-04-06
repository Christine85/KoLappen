using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class FormQuestion
    {
        public int FormQuestionId { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
    }
}
