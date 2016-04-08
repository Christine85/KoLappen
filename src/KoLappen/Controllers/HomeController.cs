using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using KoLappen.ViewModels;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KoLappen.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        SignInManager<IdentityUser> signInManager;

        public HomeController(SignInManager<IdentityUser> signInManager)
                    {
            this.signInManager = signInManager;
        }
        // GET: /<controller>/
        public async Task<ActionResult> Index()
        {
            //var autoLogin = true;

            //if (autoLogin)
            //{
            //    await signInManager.PasswordSignInAsync("admin@admin.com", "P@ssw0rd", false, false);
            //    return View();
            //}

            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }
    }
}
