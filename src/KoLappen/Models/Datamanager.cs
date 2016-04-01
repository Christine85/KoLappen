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

        public QueListVM[] GetQue(string userName)
        {
            var queList = context.Users
                .Where(o => o.NeedHelp == true)
               //.OrderBy(o => o.HelpTime)
               .Select(o => new QueListVM
               {
                   Firstname = o.Firstname,
                   Lastname = o.Lastname,
                   //HelpTime = o.HelpTime.Value,
                   UserName = o.UserName,
                   QueNr = 0,
                   IsUserItem = o.UserName == userName ? true : false

               })
               .ToArray();

            for (int i = 0; i < queList.Length; i++)
            {
                queList[i].QueNr = i + 1;
            }

            return queList;
        }

        public void HelpTrueOrFalse(string UserName, bool trueOrFalse)
        {
            var user = context.Users
              .Where(o => o.UserName == UserName).SingleOrDefault();

            if(user != null)
            {
                user.NeedHelp = trueOrFalse;

                context.SaveChanges();
            }
        }
    }
}
