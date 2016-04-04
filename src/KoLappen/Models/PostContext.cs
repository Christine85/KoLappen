using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class PostContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().ToTable("Posts");
        }
    }

    public class Post
    {
        public int Id { get; set; }
        public string PostText { get; set; }
        public string Link { get; set; }
        public string PostedByFirstname { get; set; }
        public string PostedByLastname { get; set; }
        public DateTime TimePosted { get; set; }
    }
}

