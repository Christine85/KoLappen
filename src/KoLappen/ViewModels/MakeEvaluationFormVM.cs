using KoLappen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class MakeEvaluationFormVM
    {
        public int EducationId { get; set; }
        public int EducationWeek { get; set; }
        public List<Evaluation> Question { get; set; }
        public int MyProperty { get; set; }
    }
}
