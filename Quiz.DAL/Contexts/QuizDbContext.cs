using Microsoft.EntityFrameworkCore;
using Quiz.DAL.Models.Categories;
using Quiz.DAL.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.DAL.Contexts
{
    public class QuizDbContext:DbContext
    {


        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuizDbContext).Assembly);//3shan ygeb al ssembly fe el project da bs 
            modelBuilder.Entity<Category>().HasData(
          new Category { Id = 1, Name = "Toys" },
          new Category { Id = 2, Name = "Clothing" },
          new Category { Id = 3, Name = "Furniture" },
          new Category { Id = 4, Name = "Electronics"}
          );
        }


        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }


    }
}
