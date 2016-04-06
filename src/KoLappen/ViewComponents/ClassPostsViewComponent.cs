using KoLappen.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewComponents
{
    public class ClassPostsViewComponent : ViewComponent
    {
        IPostsRepository _postsRepository;
        public ClassPostsViewComponent(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }
        // GET: /<controller>/
        public IViewComponentResult Invoke()
        {
            var model = _postsRepository.GetAll();
            return View(model);
        }





    }
}
