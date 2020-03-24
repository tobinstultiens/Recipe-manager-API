using RecipeManager.API.Domain.Entities;
using RecipeManager.API.Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeManager.API.Infrastructure.Services
{
    public class RecipeService
    {
        private readonly UnitOfWork _unitOfWork;

        public RecipeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Recipe GetRecipe(Guid id)
        {
            try
            {
                return _unitOfWork.RecipeRepository.GetById(id);
            }
            catch (Exception)
            {

            }

            return null;
        }

        public List<Recipe> GetRecipes(string recipeTitle)
        {
            try
            {
                return _unitOfWork.RecipeRepository.Get(recipe => recipe.Title.Contains(recipeTitle)).ToList();
            }
            catch (Exception)
            {

            }

            return null;
        }

        public List<Recipe> GetRecipes()
        {
            try
            {
                return _unitOfWork.RecipeRepository.Get(orderBy: q => q.OrderByDescending(d => d.CreationDateTime)).ToList();
            }
            catch (Exception)
            {

            }

            return null;
        }

        public void CreateRecipe(Recipe recipe)
        {
            try
            {
                _unitOfWork.RecipeRepository.Insert(recipe);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

            }
        }

        public void UpdateRecipe(Recipe recipe)
        {
            try
            {
                _unitOfWork.RecipeRepository.Update(recipe);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

            }
        }

        public void DeleteRecipe(Recipe recipe)
        {
            try
            {
                _unitOfWork.RecipeRepository.Delete(recipe);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

            }
        }

        public void DeleteRecipe(Guid id)
        {
            try
            {
                _unitOfWork.RecipeRepository.Delete(id);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

            }
        }
    }
}