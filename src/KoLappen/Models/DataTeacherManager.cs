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
        public void MakeEvaluationForm()
        {
            ////Hämtar användaren som skall ändras i DB
            //var user = context.Users.SingleOrDefault(o => o.UserName == userName);

            ////Om användaren hittas, uppdatera DB (HelpTime och NeedHelp)
            //if (user != null)
            //{
            //    if (needHelp == true)
            //    {
            //        user.HelpTime = DateTime.Now;
            //    }
            //    user.NeedHelp = needHelp;
            //    context.SaveChanges();
            //}
        }
    }
}
