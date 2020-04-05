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
        bool CreateRecipe(Recipe recipe);
        bool UpdateRecipe(Recipe recipe);
        bool DeleteRecipe(Recipe recipe);
        bool DeleteRecipe(Guid id);
    }
}