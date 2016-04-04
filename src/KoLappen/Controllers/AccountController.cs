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
        IProfileRepository profileDataManager;

        public AccountController(
            UserManager<IdentityUser> userManager, //skapa ny användare
            SignInManager<IdentityUser> signInManager, //logga in
            IdentityDbContext contextIdentity,
            IUsersRepository usersRepository,
            DBContext dbContext,
            IProfileRepository profileDataManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.contextIdentity = contextIdentity;
            this.usersRepository = usersRepository;
            this.dbContext = dbContext;
            this.profileDataManager = profileDataManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Katalog()
        {
            //ProfileDataManager pdm = new ProfileDataManager(dbContext, contextIdentity);
            return View(profileDataManager.GetOneClass(1));
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

            return RedirectToAction(nameof(HomeController.Index), "home");
        }


        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccountController.Login));
        }

        [AllowAnonymous]
        public ActionResult AddUser()
        {
            //ViewBag.Educations = new SelectList(dbContext.Educations, "EducationID", "CourseName");
            //ViewBag.JobAreas = new SelectList(dbContext.JobAreas, "JobAreaID", "JobAreaID");
            var viewModel = new AddUserViewModel();
            //viewModel.allEducations = usersRepository.GetAllEducations();
            //viewModel.allJobAreas = usersRepository.GetJobAreas();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(AddUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Skapa DB-schemat
            await contextIdentity.Database.EnsureCreatedAsync();

            // Skapa användaren
            IdentityUser user = new IdentityUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email
            };
            var result = await userManager.CreateAsync(user, "P@ssw0rd");

            if (result.Succeeded)
            {
                // Om användaren skapades så skapas även en rad i tabellen 'Users'
                usersRepository.AddUser(viewModel, user.Id);

                await signInManager.PasswordSignInAsync(
                    viewModel.Email, "P@ssw0rd", false, false);

                return RedirectToAction(nameof(HomeController.Index), "home");
            }

            // Visa ev. fel-meddelande
            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(AddUserViewModel.Email),
                    result.Errors.First().Description);

                return View(viewModel);
            }
            return View(viewModel);
        }
    }
}