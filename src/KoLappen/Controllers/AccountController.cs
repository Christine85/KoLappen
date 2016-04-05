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
using Microsoft.AspNet.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KoLappen.Controllers
{
    public class AccountController : Controller
    {
        DBContext dbContext;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        IdentityDbContext contextIdentity;
        IUsersRepository usersRepository;

        public AccountController(
            DBContext dbContext,
            UserManager<IdentityUser> userManager, //skapa ny användare
            SignInManager<IdentityUser> signInManager, //logga in
            IdentityDbContext contextIdentity,
            IUsersRepository usersRepository
            )
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.contextIdentity = contextIdentity;
            this.usersRepository = usersRepository;
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

            var result = await signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, false, false);

            //om admin eller lärare loggar in, skall de få en annan view
            var user = contextIdentity.Users.Single(o => o.UserName == viewModel.UserName);
            if (await userManager.IsInRoleAsync(user, "Admin"))
            {
                return RedirectToAction(nameof(AdminController.Index), "Admin");
            }
            else if (await userManager.IsInRoleAsync(user, "Lärare"))
            {
                return RedirectToAction(nameof(TeacherController.Index), "Teacher");
            }
            return RedirectToAction(nameof(HomeController.Index), "home");
        }


        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccountController.Login));
        }


        [AllowAnonymous]
        public ActionResult CreateUser()
        {
            //ViewBag.Educations = new SelectList(dbContext.Educations, "EducationID", "CourseName");
            //ViewBag.JobAreas = new SelectList(dbContext.JobAreas, "JobAreaID", "JobAreaID");
            //viewModel.allEducations = usersRepository.GetAllEducations();
            //viewModel.allJobAreas = usersRepository.GetJobAreas();
            var viewModel = new CreateUserViewModel();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Skapa DB-schemat
            await contextIdentity.Database.EnsureCreatedAsync();

            // Skapa användaren
            IdentityUser user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await userManager.CreateAsync(user, "P@ssw0rd");

            if (result.Succeeded)
            {
                // Om användaren skapades så skapas även en rad i tabellen 'Users'
                usersRepository.CreateUser(model, user.Id);

                await signInManager.PasswordSignInAsync(
                    model.Email, "P@ssw0rd", false, false);

                return RedirectToAction(nameof(HomeController.Index), "home");
            }

            // Visa ev. fel-meddelande
            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(CreateUserViewModel.Email),
                    result.Errors.First().Description);

                return View(model);
            }
            return View(model);
        }
    }
}