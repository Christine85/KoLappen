using KoLappen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class DataTeacherManager
    {
        DBContext context;

        public DataTeacherManager(DBContext context)
        {
            this.context = context;
        }
        public /*List<MakeFormVM>*/ void MakeEvaluationForm(MakeFormVM makeEvaluationForm)
        {
            //Hämtar användaren som skall ändras i DB
            var evaluationForm = context.Consultant.SingleOrDefault(o => o.User.UserName == "Christine");

            //Om användaren hittas, uppdatera DB (HelpTime och NeedHelp)
            if (evaluationForm != null)
            {
                evaluationForm.HelpTime = DateTime.Now;

                context.SaveChanges();
            }

            //return evaluationForm;
        }
    }
}
