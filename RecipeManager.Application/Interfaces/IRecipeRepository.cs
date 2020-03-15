using System.Collections.Generic;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Application.Interfaces
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipeById(int recipeId);
        void InsertRecipe(Recipe recipe);
        void DeleteRecipe(int recipeID);
        void UpdateRecipe(Recipe student);
        void Save();
    }
}