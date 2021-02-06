using Microsoft.EntityFrameworkCore;
using System;
using MyRedditClientDataAccessLib.Model;

namespace MyRedditClientDataAccessLib
{
    public class MyRedditClientDbContext : DbContext
    {
        private const string connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        public MyRedditClientDbContext() : base()
        {
            Database.EnsureCreated();
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