using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Authorization;
using KoLappen.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KoLappen.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        IdentityDbContext contextIdentity;
        public AccountController(
            UserManager<IdentityUser> userManager, //skapa ny användare
            SignInManager<IdentityUser> signInManager, //logga in
             IdentityDbContext contextIdentity)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.contextIdentity = contextIdentity;            

        }
        // GET: /<controller>/
        public IActionResult Index()
        {            
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            //skapa DB-schemat
            //await contextIdentity.Database.EnsureCreatedAsync();

            //skapa användaren
            //var result = await userManager.CreateAsync(new IdentityUser(viewModel.UserName), viewModel.Password);
            /*
            //visa ev. felmeddelande
            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(LoginVM.UserName), result.Errors.First().Description);
                return View(viewModel);
            }
            */
            await signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, false, false);

            return RedirectToAction(nameof(HomeController.Index),"home");
        }


        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccountController.Login));
        }
    }
}
