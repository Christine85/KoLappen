﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using KoLappen.Models;
using KoLappen.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KoLappen.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        DBContext context;
        public AdminController(DBContext context)
        {
            this.context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return Content("admin");
        }

        //Skapa utvärderingformulär
        public IActionResult MakeEvaluationForm(MakeFormVM viewModel)
        {
            var dataManagerForm = new DataManagerForm(context);

            //Skapa utvärderingsformulär
            dataManagerForm.MakeEvaluationForm(viewModel);
            var showEvaluationForm = dataManagerForm.ShowEvaluationForm(viewModel);

            return View();
        }

        public IActionResult AddEvaluation()
        {
            //var model = new MakeFormVM();
            //model.EducLocationItems = new SelectListItem[]
            //{
            //    new SelectListItem { Text = "Stockholm", Value = "Stockholm" },
            //    new SelectListItem { Text = "Göteborg", Value = "Göteborg" }
            //};
            //return View(model);
            return View();
        }



    }



}

