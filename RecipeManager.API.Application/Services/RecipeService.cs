using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using RecipeManager.API.Application.Dtos;
using RecipeManager.API.Application.Interfaces;
using RecipeManager.API.Domain.Entities;
using RecipeManager.API.Persistence.EntityFramework;

namespace RecipeManager.API.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<RecipeService> _logger;
        private readonly IMapper _mapper;

        public RecipeService(UnitOfWork unitOfWork, ILogger<RecipeService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
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

        public List<RecipeDto> GetRecipes(string recipeTitle)
        {
            try
            {
                return _mapper.Map<List<RecipeDto>>(_unitOfWork.RecipeRepository.Get(recipe => recipe.Title.Contains(recipeTitle)).ToList());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to retrieve the list of recipes.");
            }

            return null;
        }

        public List<RecipeDto> GetRecipes(int size, int page)
        {
            try
            {
                return _mapper.Map<List<RecipeDto>>(_unitOfWork.RecipeRepository
                    //Keeping this commented in case it's needed.
                    .Get( /*orderBy: q => q.OrderByDescending(d => d.CreationDateTime)*/)
                    //This will mean it will have to start with 1 otherwise it will return a error
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList());
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