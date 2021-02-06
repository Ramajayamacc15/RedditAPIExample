using Microsoft.EntityFrameworkCore;
using System;
using MyRedditClientDataAccessLib.Model;

namespace MyRedditClientDataAccessLib
{
    public class MyRedditClientDbContext : DbContext
    {
        private const string connectionString = "Server=localhost\\SQLEXPRESS;Database=MyReddit;Trusted_Connection=True;";

        public MyRedditClientDbContext() : base()
        {
            Database.EnsureCreated();
            var task = SubReddits.CountAsync();
            if (task.Result <= 0)
            {
                SubReddits.Add(new SubReddit { Name = "science" });
                SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<SubReddit> SubReddits { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}