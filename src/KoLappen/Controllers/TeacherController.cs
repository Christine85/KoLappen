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
    [Authorize(Roles = "Lärare")]
    public class TeacherController : Controller
    {
        DBContext context;
        public TeacherController(DBContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EvaluationForm()
        {
            var dataTeacherManager = new DataTeacherManager(context);
            //Hämta lista på folk i kö
            //var evaluationForm = dataTeacherManager.MakeEvaluationForm(User.Identity.Name);
            return PartialView("_QueueForm");
        }
    }
}
