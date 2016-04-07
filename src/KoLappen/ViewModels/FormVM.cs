using KoLappen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KoLappen.ViewModels
{
    public class FormVM
    {
        public class MakeFormVM
        {
            public string CourseName { get; set; }
            public string SemesterName { get; set; }
            public string City { get; set; }
            public int EducationWeek { get; set; }
            public string Question { get; set; }
            public List<FormOption> Options { get; set; }
            public int FormQuestionToOptionId { get; set; }
            public int QuestionId { get; set; }
            public int Score { get; set; }
        }


        public class EvaluationFormVM
        {
            public int EducationId { get; set; }
            public int EducationWeek { get; set; }
            public string Question { get; set; }
            public int QuestionId { get; set; }
            public List<FormOption> Options { get; set; }
        }

        public class CreateEvaluationVM
        {
            public string Cities { get; set; }

        }
    }
}
