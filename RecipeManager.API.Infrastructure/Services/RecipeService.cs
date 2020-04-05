using RecipeManager.API.Application.Interfaces;
using RecipeManager.API.Domain.Entities;
using RecipeManager.API.Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace RecipeManager.API.Infrastructure.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<RecipeService> _logger;

        public RecipeService(UnitOfWork unitOfWork, ILogger<RecipeService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public Recipe GetRecipe(Guid id)
        {
            try
            {
                return _unitOfWork.RecipeRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to retrieve the recipe.");
            }

            return null;
        }

        public List<Recipe> GetRecipes(string recipeTitle)
        {
            try
            {
                return _unitOfWork.RecipeRepository.Get(recipe => recipe.Title.Contains(recipeTitle)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to retrieve the list of recipes.");
            }

            return null;
        }

        public List<Recipe> GetRecipes(int size, int page)
        {
            try
            {
                return _unitOfWork.RecipeRepository
                    //Keeping this commented in case it's needed.
                    .Get( /*orderBy: q => q.OrderByDescending(d => d.CreationDateTime)*/)
                    //This will mean it will have to start with 1 otherwise it will return a error
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to retrieve the pagination");
            }

            return null;
        }

        public bool CreateRecipe(Recipe recipe)
        {
            try
            {
                _unitOfWork.RecipeRepository.Insert(recipe);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create a recipe");
                return false;
            }
        }

        public bool UpdateRecipe(Recipe recipe)
        {
            try
            {
                _unitOfWork.RecipeRepository.Update(recipe);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to update the recipe");
                return false;
            }
        }

        public bool DeleteRecipe(Recipe recipe)
        {
            try
            {
                _unitOfWork.RecipeRepository.Delete(recipe);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to delete the recipe");
                return false;
            }
        }

        public bool DeleteRecipe(Guid id)
        {
            try
            {
                _unitOfWork.RecipeRepository.Delete(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to delete the recipe");
                return false;
            }
        }
    }
}