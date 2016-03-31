using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using KoLappen.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KoLappen.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        DBContext context;

        public ProfileController(DBContext context)
        {
            this.context = context;
        }
        // GET: /<controller>/
        public IActionResult Profile()
        {
            return View();
        }

    }
}
