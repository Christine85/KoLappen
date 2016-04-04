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
            //Hämta lista på användare som behöver hjälp
            var queueList = context.Users
                .Where(o => o.NeedHelp == true)
                .OrderBy(o => o.HelpTime)
               .Select(o => new QueueListVM
               {
                   Firstname = o.Firstname,
                   Lastname = o.Lastname,
                   HelpTime = o.HelpTime,
                   UserName = o.UserName,
                   //Om den som är inloggad finns i kön, sätt till true
                   IsUserItem = o.UserName == userName ? true : false

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
            var user = context.Users.SingleOrDefault(o => o.UserName == userName);

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
