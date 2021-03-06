﻿using System;
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
    [Route("AWA")]
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
        [Route("Profil")]
        public IActionResult Profile()
        {
            return View(dataManager.GetProfile(User.Identity.Name));
        }
        [Route("Redigera")]
        // GET: /<controller>/
        public IActionResult EditProfile()
        {
            return View(dataManager.GetProfileToEdit(User.Identity.Name));
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileVM model)
        {
            model.UserId = User.Identity.Name;
            await dataManager.EditProfile(model);
            return RedirectToAction(nameof(ProfileController.Profile));
        }

    }
}
