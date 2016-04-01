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

        public void HelpNeeded(string UserName)
        {
            //context.Users
            //  .Where(o => o.UserName == UserName)
            //  .Select(o =>
            //  {

            //      o.NeedHelp = true


            //      });




            ////kolla hur många som finns med samma email
            //var result = context.Users.Count(o => o.Email.Equals(viewModel.Email));

            //user.FirstName = viewModel.FirstName;
            //user.LastName = viewModel.LastName;
            //user.Email = viewModel.Email;
            //user.PhoneNumber = viewModel.PhoneNumber;
            //user.IsAdmin = "0";

            //context.Users.Add(user);
            //context.SaveChanges();

            ////spara id för kunden
            //userID = user.UserId;

            //var adress = new Address();

            //adress.Street = viewModel.Street;
            //adress.Zip = viewModel.Zip;
            //adress.City = viewModel.City;
            //adress.UserID = userID;

            //context.Addresses.Add(adress);
            //context.SaveChanges();

            //var security = new Security();

            //security.Email = viewModel.Email;
            //security.Password = viewModel.Password;

            //context.Securitys.Add(security);
            //context.SaveChanges();

            ////true om kund lagts till i DB
        }

        public void NoHelpNeeded(string UserName)
        {
        }
    }
}
