using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        public int EducationId { get; set; }
        public int EducationWeek { get; set; }
        public string Question { get; set; }
    }
}
