﻿using KoLappen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public interface IPostsRepository
    {
        PostListVM[] GetAll();
        void AddPost(AddPostVM viewModel, string postedBy);
    }

    public class DbPostsRepository : IPostsRepository
    {
        DBContext _context;
        public DbPostsRepository(DBContext context)
        {
            _context = context;
        }
        public PostListVM[] GetAll()
        {
            return _context.Posts
                .OrderByDescending(o => o.TimePosted)
                .Select(o => new PostListVM
                {
                    PostText = o.PostText,
                    Link = o.Link,
                    PostedByFirstname = o.User.Firstname,
                    PostedByLastname = o.User.Lastname,
                    TimePosted = o.TimePosted
                })
                .ToArray();
        }





        public void AddPost(AddPostVM viewModel, string postedBy)
        {
            var user = _context.Users.Where(u => u.UserName == postedBy).Single();
            _context.Posts.Add(new Post
            {
                UserID = user.UserId,
                PostText = viewModel.PostText,
                Link = viewModel.Link,
                TimePosted = DateTime.Now
            });
            _context.SaveChanges();
        }
    }




    // Test nedan används ej..... Kan aktiveras i Startup
    public class TestPostsRepository : IPostsRepository
    {
        public void AddPost(AddPostVM viewModel, string postedByName)
        {
            throw new NotImplementedException();
        }
        public PostListVM[] GetAll()
        {
            return new PostListVM[]
            {
                new PostListVM { PostText="Hej, jag är ett testinlägg.....", Link="http://www.google.se", PostedByFirstname = "Kjell", PostedByLastname = "Hansson" },
                new PostListVM { PostText="Funkar detta tro??", Link="http://www.outlook.com", PostedByFirstname ="Sven", PostedByLastname = "Svensson" },
                new PostListVM { PostText="Hej, jag är Christine!!!.....", Link="http://www.hattrick.org", PostedByFirstname = "Christine", PostedByLastname = "Geidemark" },
            };
        }
    }
}
