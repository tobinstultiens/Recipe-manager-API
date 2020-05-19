using RecipeManager.API.Domain.Entities;
using RecipeManager.API.Persistence.EntityFramework.Generics;

namespace RecipeManager.API.Persistence.EntityFramework
{
    public interface IUnitOfWork
    {
        GenericRepository<Ingredient> IngredientRepository { get; }
        GenericRepository<Recipe> RecipeRepository { get; }
        GenericRepository<RecipeTime> RecipeTimeRepository { get; }
        GenericRepository<Direction> DirectionRepository { get; }
        void Save();
        void Dispose();
    }
}