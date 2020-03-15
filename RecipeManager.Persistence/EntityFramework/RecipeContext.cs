using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Persistence.EntityFramework
{
    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Test");
        }
    }
}
