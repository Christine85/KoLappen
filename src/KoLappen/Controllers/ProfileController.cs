using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using KoLappen.Models;
using KoLappen.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KoLappen.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        IProfileRepository dataManager;
        //ProfileDataManager dataManager;
        public ProfileController(DBContext context,
        IdentityDbContext identityContext,
        IProfileRepository repo)
        {
            dataManager = repo;
            //dataManager = new ProfileDataManager(context, identityContext);
        }
        
        public IActionResult Profile()
        {
            return View(dataManager.GetProfile(User.Identity.Name));
        }
        // GET: /<controller>/
        public IActionResult EditProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditProfile(ProfileVM model)
        {
            return RedirectToAction(nameof(ProfileController.Profile));
        }

    }
}
