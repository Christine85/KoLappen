using KoLappen.ViewModels;
using Microsoft.Data.Entity;
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
            //Ändra användaren i DB
            var user = context.Consultant
                .Where(o => o.User.UserName == userName)
                .Select(o => new Consultant
                {
                    ConsultantId = o.ConsultantId,
                    UserId = o.UserId,
                    EducationId = o.EducationId,
                    HelpTime = DateTime.Now,
                    NeedHelp = needHelp
                })
                .SingleOrDefault();

            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}
