using KoLappen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class DataManager
    {
        DBContext context;

        public DataManager(DBContext context)
        {
            this.context = context;
        }

        public QueueListVM[] GetQueue(string userName)
        {
            //Hämta de som behöver hjälp
            var queueList = context.Consultant
                .Where(o => o.NeedHelp == true)
                .OrderBy(o => o.HelpTime)
                .Select(o => new QueueListVM
                {
                    Firstname = o.User.Firstname,
                    Lastname = o.User.Lastname,                   
                    HelpTime = o.HelpTime,
                    IsUserItem = o.User.UserName == userName ? true : false
                })
               .ToArray();

            //Sätt vilket kö nr som varje användare har, gör om DateTime till TotalMinutes för att visa upp
            for (int i = 0; i < queueList.Length; i++)
            {
                queueList[i].QueueNr = i + 1;
                TimeSpan result = DateTime.Now - queueList[i].HelpTime;
                int resultInMin = Convert.ToInt32(result.TotalMinutes);
                queueList[i].TimeWaitedInMin = resultInMin;
            }
            return queueList;
        }

        public void HelpTrueOrFalse(string userName, bool needHelp)
        {
            //Hämtar användaren som skall ändras i DB
            var user = context.Consultant.SingleOrDefault(o => o.User.UserName == userName);

            //Om användaren hittas, uppdatera DB (HelpTime och NeedHelp)
            if (user != null)
            {
                if (needHelp == true)
                {
                    user.HelpTime = DateTime.Now;
                }
                user.NeedHelp = needHelp;
                context.SaveChanges();
            }
        }
    }
}
