using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KoLappen.Models;
using KoLappen.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KoLappen.Controllers
{
    public class QuelistController : Controller
    {
        DBContext context;

        public QuelistController(DBContext context)
        {
            this.context = context;            
        }
        // GET: /<controller>/
        //public IActionResult Quelist()
        //{
        //    try
        //    {
        //        var dataManager = new DataManager(context);
        //        var queList = dataManager.GetQue(User.Identity.Name);
        //        return View(queList);
        //    }
          
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError(string.Empty, e.Message);
        //        return View();
        //    }            
        //}

        public IActionResult NeedHelpTrueOrFalse(bool trueOrFalse)
        {
            try
            {
                var dataManager = new DataManager(context);
                dataManager.HelpTrueOrFalse(User.Identity.Name, trueOrFalse);
                return ViewComponent("QueListViewComponent");
                            }

            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }            
        }
       
    }
}
