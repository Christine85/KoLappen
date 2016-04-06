using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class FormQuestionToOption
    {
        public FormOption FormOption { get; set; }
        public FormQuestion FormQuestion { get; set; }
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public int FormQuestionToOptionId { get; set; }
    }
}
