using Microsoft.AspNetCore.Mvc;
using RecipeManager.API.Application.Interfaces;
using RecipeManager.API.Domain.Entities;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using RecipeManager.API.ViewModels;

namespace RecipeManager.API.Controllers
{
    /// <summary>
    /// The recipe controller
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        /// <summary>
        /// Get the recipe with the help of pagination
        /// </summary>
        /// <param name="paging">pagination parameter</param>
        /// <returns>this returns a list of recipes</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] Paging paging)
        {
            var result = _recipeService.GetRecipes(paging.Size, paging.Page, paging.Uid);
            return result == null ? (IActionResult) new NotFoundResult() : new OkObjectResult(result);
        }

        /// <summary>
        /// Get the specific recipe specified with the guid
        /// </summary>
        /// <param name="id">Guid parameter</param>
        /// <returns>Return that specific recipe</returns>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var result = _recipeService.GetRecipe(id);
            return result == null ? (IActionResult) new NotFoundResult() : new OkObjectResult(result);
        }

        /// <summary>
        /// Creates the recipe
        /// </summary>
        /// <param name="recipe">The recipe that is created</param>
        /// <returns>return if it succeeded or not</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
            bool success = _recipeService.CreateRecipe(recipe);
            return !success ? (IActionResult) new BadRequestResult() : new AcceptedResult();
        }

        /// <summary>
        /// Update the recipe object specified in this request.
        /// </summary>
        /// <param name="recipe">The object that needs to be updated</param>
        /// <returns>Returns the result of this request</returns>
        [HttpPut]
        public IActionResult Put([FromBody] Recipe recipe)
        {
            bool success = _recipeService.UpdateRecipe(recipe);
            return !success ? (IActionResult) new BadRequestResult() : new AcceptedResult();
        }

        /// <summary>
        /// Delete the specified recipe.
        /// </summary>
        /// <param name="id">The id of the recipe</param>
        /// <returns>returns if it succeeded with the removal of this recipe</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            bool success = _recipeService.DeleteRecipe(id);
            return !success ? (IActionResult) new BadRequestResult() : new AcceptedResult();
        }
    }
}