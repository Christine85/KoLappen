using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using KoLappen.Models;
using KoLappen.ViewModels;

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

        //Skapa tentaformulär
        public IActionResult MakeExamForm(MakeFormVM viewModel)
        {
            var dataManagerForm = new DataManagerForm(context);           
            /*var examForm = */dataManagerForm.MakeExamForm(viewModel);

            return View(/*examForm*/);
        }

    
        public IActionResult GetListOfExamForm()
        {
            var dataManagerForm = new DataManagerForm(context);
           
            /*var examForm = */
            //dataManagerForm.MakeExamForm();

            return View(/*examForm*/);
        }
    }
}
