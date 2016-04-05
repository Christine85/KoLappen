using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class EvaluationAnswer
    {
        public int UserId { get; set; }
        public int EvaluationId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
    }
}
