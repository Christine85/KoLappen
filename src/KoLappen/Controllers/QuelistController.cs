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
        public IActionResult GetQuelist()
        {
            var dataManager = new DataManager(context);
            var queList = dataManager.GetQue(User.Identity.Name);
            return PartialView("_QueForm", queList);
        }

        [HttpPost]
        public IActionResult Dequeue()
        {
            return UpdateNeedHelp(false);
        }

        [HttpPost]
        public IActionResult Enqueue()
        {
            return UpdateNeedHelp(true);
        }

        private IActionResult UpdateNeedHelp(bool isEnqueue)
        {
            var dataManager = new DataManager(context);
            dataManager.HelpTrueOrFalse(User.Identity.Name, isEnqueue);
            var queList = dataManager.GetQue(User.Identity.Name);
            return PartialView("_QueForm", queList);
        }
    }
}
