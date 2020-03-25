﻿using Microsoft.AspNetCore.Mvc;
using RecipeManager.API.Application.Interfaces;
using RecipeManager.API.Domain.Entities;
using System;
using System.Collections.Generic;
using RecipeManager.API.ViewModels;

namespace RecipeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: api/Recipe
        [HttpGet]
        public List<Recipe> Get([FromQuery]Paging paging)
        {
            return _recipeService.GetRecipes(paging.Size, paging.Page);
        }

        // GET: api/Recipe/5
        [HttpGet("{id}", Name = "Get")]
        public Recipe Get(Guid id)
        {
            return _recipeService.GetRecipe(id);
        }

        // POST: api/Recipe
        [HttpPost]
        public void Post([FromBody] Recipe recipe)
        {
            try
            {
                _recipeService.CreateRecipe(recipe);
            }
            catch (Exception)
            {

            }
        }

        // PUT: api/Recipe/5
        [HttpPut]
        public void Put([FromBody] Recipe value)
        {
            try
            {
                _recipeService.UpdateRecipe(value);
            }
            catch (Exception)
            {

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                _recipeService.DeleteRecipe(id);
            }
            catch (Exception)
            {

            }
        }
    }
}
