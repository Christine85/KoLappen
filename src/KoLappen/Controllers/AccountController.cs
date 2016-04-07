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
    public class AccountController : Controller
    {
        DBContext dbContext;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        //IdentityDbContext contextIdentity;
        IAccountRepository accountRepository;

        public AccountController(
            DBContext dbContext,
            UserManager<IdentityUser> userManager, //skapa ny användare
            SignInManager<IdentityUser> signInManager, //logga in
            //IdentityDbContext contextIdentity,
            IAccountRepository accountRepository
            )
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            //this.contextIdentity = contextIdentity;
            this.accountRepository = accountRepository;
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

            if (result.Succeeded)
            {
            var user = dbContext.Users.Single(o => o.UserName == viewModel.UserName);
            var aspUser = userManager.Users.Single(o => o.UserName == viewModel.UserName);
            //var aspUser = contextIdentity.Users.Single(o => o.UserName == viewModel.UserName);
             
            // Om användarprofilen ('Users' tabellen) är komplett så loggas användaren in
            if (user.RegistrationComplete == true)
            {
                //om admin eller lärare loggar in, skall de få en annan view
                //if (await userManager.IsInRoleAsync(aspUser, "Admin"))
                //{
                //    return RedirectToAction(nameof(AdminController.Index), "Admin");
                //}
                //else if (await userManager.IsInRoleAsync(aspUser, "Lärare"))
                //{
                //    return RedirectToAction(nameof(TeacherController.Index), "Teacher");
                //}
                return RedirectToAction(nameof(HomeController.Index), "home");
            }

            // Annars uppmanas användaren att färdigställa sin profil

            if (aspUser.EmailConfirmed == true && user.RegistrationComplete == false)
                return RedirectToAction(nameof(AccountController.CompleteRegistration), "account");

            if (aspUser.EmailConfirmed == false)
                return RedirectToAction(nameof(AccountController.CompleteRegistration), "account");
            else
                return RedirectToAction(nameof(AccountController.CompleteRegistration), "login");

            }
            else
                return RedirectToAction(nameof(AccountController.Login));


        }


        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccountController.Login));
        }


        [AllowAnonymous]
        public ActionResult RegisterUser()
        {
            //ViewBag.Educations = new SelectList(dbContext.Educations, "EducationID", "CourseName");
            //ViewBag.JobAreas = new SelectList(dbContext.JobAreas, "JobAreaID", "JobAreaID");
            //viewModel.allEducations = usersRepository.GetAllEducations();
            //viewModel.allJobAreas = usersRepository.GetJobAreas();
            var model = accountRepository.GetRegistrationOptions();
            return View(model);
            //var viewModel = new RegisterUserViewModel();
            //return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Skapa DB-schemat
            //await contextIdentity.Database.EnsureCreatedAsync();

            // Skapa användaren
            IdentityUser user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            //var passReset = userManager.GeneratePasswordResetTokenAsync(user);


            //var u = Membership.GetAllUsers();//("goteborg@goteborg.se");
            //u.ResetPassword();



            var result = await userManager.CreateAsync(user, "P@ssw0rd");

            if (result.Succeeded)
            {
                // Om användaren skapades så skapas även en rad i tabellen 'Users', 'Consultants' och 'UserJobLocation'
                accountRepository.CompleteUser(model, user.Id);

                await signInManager.PasswordSignInAsync(
                    model.Email, "P@ssw0rd", false, false);

                return RedirectToAction(nameof(HomeController.Index), "home");
            }

            // Visa ev. fel-meddelande
            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(RegisterUserViewModel.Email),
                    result.Errors.First().Description);

                return View(model);
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ViewMe()
        {
            var model = accountRepository.GetAllConsultants();
            return View(model);
        }

        public ActionResult CompleteRegistration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CompleteRegistration(CompleteRegistrationViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(
                model.Email, model.VerificationPassword, false, false);

            if (result.Succeeded)
        {
                var user = await userManager.FindByNameAsync(model.Email);

                var passResult = await userManager.ChangePasswordAsync(user, model.VerificationPassword, model.Password);


                if (passResult.Succeeded)
            accountRepository.CompleteRegistration(model);

            }
            return View();
        }
    }
}