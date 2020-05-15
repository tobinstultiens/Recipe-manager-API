using RecipeManager.API.Domain.Entities;
using RecipeManager.API.Persistence.EntityFramework.Contexts;
using RecipeManager.API.Persistence.EntityFramework.Generics;
using System;

namespace RecipeManager.API.Persistence.EntityFramework
{
    /// <summary>
    /// Unit of work is there to make sure only a singe database context is used even with multiple repositories.
    /// </summary>
    public sealed class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly RecipeContext _context;
        private GenericRepository<Ingredient> _ingredientRepository;
        private GenericRepository<Recipe> _recipeRepository;
        private GenericRepository<RecipeTime> _recipeTimeRepository;
        private GenericRepository<Direction> _directionRepository;

        public GenericRepository<Ingredient> IngredientRepository => _ingredientRepository ??= new GenericRepository<Ingredient>(_context);

        public GenericRepository<Recipe> RecipeRepository => _recipeRepository ??= new GenericRepository<Recipe>(_context);

        public GenericRepository<RecipeTime> RecipeTimeRepository => _recipeTimeRepository ??= new GenericRepository<RecipeTime>(_context);

        public GenericRepository<Direction> DirectionRepository => _directionRepository ??= new GenericRepository<Direction>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        public UnitOfWork(RecipeContext context)
        {
            _context = context;
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}