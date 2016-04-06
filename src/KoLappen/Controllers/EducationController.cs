using KoLappen.Models;
using KoLappen.ViewModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Controllers
{
    public class EducationController : Controller
    {
        DBContext dbContext;
        //IUsersRepository usersRepository;
        IProfileRepository profileDataManager;
        IEducationRepository educationRepository;

        public EducationController(
            DBContext dbContext,
            IAccountRepository accountRepository,
            IProfileRepository profileDataManager,
            IEducationRepository educationRepository
            )
        {
            this.dbContext = dbContext;
            this.profileDataManager = profileDataManager;
            this.educationRepository = educationRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Semester()
        //{
        //    return View();
        //}
        public IActionResult Alumner()
        {
            var viewModel = educationRepository.GetAllCourses();
            return View(viewModel);
        }

        
        public IActionResult Semester(int courseID)
        {
            var viewModel = educationRepository.GetAllSemesters(courseID);
            return View(viewModel);
        }

        public IActionResult Katalog(int id)
        {
            //var viewModel = profileDataManager.GetOneClass(id);
            return View(/*viewModel*/);
        }

        [AllowAnonymous]
        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse(AddCourseVM viewModel)
        {
            if (!ModelState.IsValid)    // kollar valideringen, returnerar ErrorMsges
            {
                return View(viewModel);
            }

            //usersRepository.AddCourse(viewModel);

            return View(viewModel);
        }
    }
}