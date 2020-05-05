using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using RecipeManager.API.Domain.Entities;

namespace RecipeManager.API.Persistence.EntityFramework.Contexts
{
    /// <summary>
    /// This class represents the <see cref="RecipeContext"/> class.
    /// </summary>
    public class RecipeContext : DbContext
    {
        private static readonly LoggerFactory MyLoggerFactory =
            new LoggerFactory(new ILoggerProvider[] {new NLogLoggerProvider()});

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<RecipeTime> RecipeTimes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public RecipeContext()
        {
        }

        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        {
        }
    }
}