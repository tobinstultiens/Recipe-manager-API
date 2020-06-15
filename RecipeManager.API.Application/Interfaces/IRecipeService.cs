using RecipeManager.API.Domain.Entities;
using System;
using System.Collections.Generic;
using RecipeManager.API.Application.Dtos;

namespace RecipeManager.API.Application.Interfaces
{
    /// <summary>
    /// The interface that defines the recipe service methods.
    /// </summary>
    public interface IRecipeService
    {
        Recipe GetRecipe(Guid id);
        List<RecipeDto> GetRecipes(string recipeTitle);
        List<RecipeDto> GetRecipes(int size, int page);
        List<RecipeDto> GetRecipes(int size, int page, string userId);
        bool CreateRecipe(Recipe recipe);
        bool UpdateRecipe(Recipe recipe);
        bool DeleteRecipe(Recipe recipe);
        bool DeleteRecipe(Guid id);
    }
}