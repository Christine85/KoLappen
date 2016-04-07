using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Authorization;
using KoLappen.ViewModels;
using KoLappen.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KoLappen.Controllers
{
    public class AdminPostController : Controller
    {
        IAdminPostsRepository _adminPostsRepository;
        public AdminPostController(
            IAdminPostsRepository adminPostsRepository)
        {
            _adminPostsRepository = adminPostsRepository;
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[Authorize]
        public IActionResult AddPost()
        {
            return View();
        }
        //[Authorize]
        [HttpPost]
        public IActionResult AddPost(AddAdminPostVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            _adminPostsRepository.AddPost(viewModel, User.Identity.Name);
            return RedirectToAction("index", "home");
        }
    }
}
