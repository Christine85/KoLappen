﻿using KoLappen.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewComponents
{
    public class QueListViewComponent : ViewComponent
    {
        DBContext context;

        public QueListViewComponent(DBContext context)
        {
            this.context = context;
        }
        public IViewComponentResult Invoke()
        {
            var dataManager = new DataManager(context);
            var queList = dataManager.GetQue(User.Identity.Name);
            return View(queList);
                       
        }
    }
}