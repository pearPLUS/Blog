using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.Areas.Identity.Data;
using MyBlog.Models;

namespace MyBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyBlog.Models.Catergory> Catergory { get; set; }
        public DbSet<MyBlog.Models.Blog> Blog { get; set; }

        public DbSet<MyBlog.Models.BlogLabel> BlogLabel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BlogLabel>().HasKey(table => new { table.BlogId, table.LabelId });
        }

        public DbSet<MyBlog.Models.label> label { get; set; }

        public DbSet<MyBlog.Models.Post> Post { get; set; }

        public DbSet<MyBlog.Models.BlogComment> BlogComment { get; set; }

        public DbSet<MyBlog.Models.TodoItem> TodoItem { get; set; }

       


    }
}
