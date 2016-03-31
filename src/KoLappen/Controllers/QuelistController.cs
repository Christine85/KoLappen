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
        public IActionResult Index(QueListVM viewModel)
        {
            return View();
        }

        public IActionResult NeedHelpFalse(QueListVM viewModel)
        {

            return View();
        }

        public IActionResult NeedHelpTrue(QueListVM viewModel)
        {

            return View();
        }
    }
}
