using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class Form
    {
        public Education Education { get; set; }
        public FormType FormType { get; set; }
        public FormToQuestion FormToQuestion { get; set; }
        public FormQuestion FormQuestion { get; set; }
        public FormConsultAnswer FormConsultAnswer { get; set; }
        public FormOption FormOption { get; set; }
        public FormQuestionToOption FormQuestionToOption { get; set; }
        public int FormId { get; set; }
        public int EducationId { get; set; }
        public int EducationWeek { get; set; }
        public int FormTypeId { get; set; }
    }
}
