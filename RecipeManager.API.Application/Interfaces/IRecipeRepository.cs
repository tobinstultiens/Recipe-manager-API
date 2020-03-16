using System.Collections.Generic;
using RecipeManager.API.Domain.Entities;

namespace RecipeManager.API.Application.Interfaces
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