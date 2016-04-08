using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KoLappen.Models;
using KoLappen.ViewModels;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KoLappen.Controllers
{
    [Authorize]
    public class QueuelistController : Controller
    {
        DBContext context;

        public QueuelistController(DBContext context)
        {
            this.context = context;
        }
        //GET: /<controller>/
        public IActionResult GetQueuelist()
        {
            var dataManager = new DataManager(context);
            //Hämta lista på folk i kö
            var queueList = dataManager.GetQueue(User.Identity.Name);
            return PartialView("_QueueForm", queueList);
        }

        [HttpPost]
        public IActionResult DeQueue()
        {
            return UpdateNeedHelp(false);
        }

        [HttpPost]
        public IActionResult EnQueue()
        {
            return UpdateNeedHelp(true);
        }

        private IActionResult UpdateNeedHelp(bool isEnqueue)
        {
            var dataManager = new DataManager(context);

            //Sätt värde i DB till true eller false för användaren
            dataManager.HelpTrueOrFalse(User.Identity.Name, isEnqueue);
            //Hämta ny updaterad lista
            var queueList = dataManager.GetQueue(User.Identity.Name);
            return PartialView("_QueueForm", queueList);
        }
    }
}
