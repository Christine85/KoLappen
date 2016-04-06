using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class FormConsultAnswer
    {
        public User User { get; set; }
        public FormQuestion FormQuestion { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
    }
}
