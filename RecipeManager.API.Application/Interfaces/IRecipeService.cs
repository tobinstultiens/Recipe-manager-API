using RecipeManager.API.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RecipeManager.API.Application.Interfaces
{
    public interface IRecipeService
    {
        Recipe GetRecipe(Guid id);
        List<Recipe> GetRecipes(string recipeTitle);
        List<Recipe> GetRecipes(int size, int page);
        void CreateRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(Recipe recipe);
        void DeleteRecipe(Guid id);
    }
}