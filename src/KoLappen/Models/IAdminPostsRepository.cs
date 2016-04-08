using KoLappen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public interface IAdminPostsRepository
    {
        AdminPostListVM[] GetAll();
        void AddPost(AddAdminPostVM viewModel, string postedBy);
    }

    public class DbAdminPostsRepository : IAdminPostsRepository
    {
        DBContext _context;
        public DbAdminPostsRepository(DBContext context)
        {
            _context = context;
        }
        public AdminPostListVM[] GetAll()
        {
            return _context.AdminPosts
                .OrderByDescending(o => o.TimePosted)
                .Select(o => new AdminPostListVM
                {
                    PostText = o.PostText,
                    Link = o.Link,
                    PostedByFirstname = o.User.Firstname,
                    PostedByLastname = o.User.Lastname,
                    TimePosted = o.TimePosted
                })
                .ToArray();
        }





        public void AddPost(AddAdminPostVM viewModel, string postedBy)
        {
            var user = _context.Users.Where(u => u.UserName == postedBy).Single();
            _context.AdminPosts.Add(new AdminPost
            {
                UserID = user.UserId,
                PostText = viewModel.PostText,
                Link = viewModel.Link,
                TimePosted = DateTime.Now
            });
            _context.SaveChanges();
        }
    }
}
