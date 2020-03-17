using System;
using RecipeManager.API.Domain.Entities;
using RecipeManager.API.Persistence.EntityFramework.Contexts;
using RecipeManager.API.Persistence.EntityFramework.Generics;

namespace RecipeManager.API.Persistence.EntityFramework
{
    /// <summary>
    /// Unit of work is there to make sure only a singe database context is used even with multiple repositories.
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        private readonly RecipeContext _context = new RecipeContext();
        private GenericRepository<Ingredient> _ingredientRepository;
        private GenericRepository<Recipe> _recipeRepository;
        private GenericRepository<RecipeTime> _recipeTimeRepository;
        private GenericRepository<Direction> _directionRepository;

        public GenericRepository<Ingredient> IngredientRepository
        {
            get
            {
                if (this._ingredientRepository == null)
                {
                    this._ingredientRepository = new GenericRepository<Ingredient>(_context);
                }
                return _ingredientRepository;
            }
        }

        public GenericRepository<Recipe> RecipeRepository
        {
            get
            {
                if (this._recipeRepository == null)
                {
                    this._recipeRepository = new GenericRepository<Recipe>(_context);
                }
                return _recipeRepository;
            }
        }

        public GenericRepository<RecipeTime> RecipeTimeRepository
        {
            get
            {
                if (_recipeTimeRepository == null)
                {
                    _recipeTimeRepository = new GenericRepository<RecipeTime>(_context);
                }
                return _recipeTimeRepository;
            }
        }

        public GenericRepository<Direction> DirectionRepository
        {
            get
            {
                if (_directionRepository == null)
                {
                    _directionRepository = new GenericRepository<Direction>(_context);
                }
                return _directionRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}