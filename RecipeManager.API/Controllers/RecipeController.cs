using Microsoft.AspNetCore.Mvc;
using RecipeManager.API.Application.Interfaces;
using RecipeManager.API.Domain.Entities;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using RecipeManager.API.ViewModels;

namespace RecipeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IRecipeService recipeService, ILogger<RecipeController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        // GET: api/Recipe
        [HttpGet]
        public IActionResult Get([FromQuery] Paging paging)
        {
            var result = _recipeService.GetRecipes(paging.Size, paging.Page);
            return result == null ? (IActionResult) new NotFoundResult() : new OkObjectResult(result);
        }

        // GET: api/Recipe/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var result = _recipeService.GetRecipe(id);
            return result == null ? (IActionResult) new NotFoundResult() : new OkObjectResult(result);
        }

        // POST: api/Recipe
        [HttpPost]
        public IActionResult Post([FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
            bool success = _recipeService.CreateRecipe(recipe);
            return success ? (IActionResult) new BadRequestResult() : new AcceptedResult();
        }

        // PUT: api/Recipe/5
        [HttpPut]
        public IActionResult Put([FromBody] Recipe value)
        {
            bool success = _recipeService.UpdateRecipe(value);
            return success ? (IActionResult) new BadRequestResult() : new AcceptedResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            bool success = _recipeService.DeleteRecipe(id);
            return success ? (IActionResult) new BadRequestResult() : new AcceptedResult();
        }
    }
}