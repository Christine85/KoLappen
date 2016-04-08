using KoLappen.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewComponents
{
    public class AdminPostsViewComponent : ViewComponent
    {
        IAdminPostsRepository _adminPostsRepository;
        public AdminPostsViewComponent(IAdminPostsRepository adminPostsRepository)
        {
            _adminPostsRepository = adminPostsRepository;
        }
        // GET: /<controller>/
        public IViewComponentResult Invoke()
        {
            var model = _adminPostsRepository.GetAll();
            return View(model);
        }
    }
}
