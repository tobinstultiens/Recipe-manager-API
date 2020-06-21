using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeManager.API.Application.Dtos;
using RecipeManager.API.Application.Interfaces;
using RecipeManager.API.Controllers;
using RecipeManager.API.Domain.Entities;
using RecipeManager.API.ViewModels;
using Xunit;

namespace RecipeManager.API.Tests
{
    public class RecipeServiceTest
    {
        private Mock<IRecipeService> _recipeService;

        public RecipeServiceTest()
        {
            _recipeService = new Mock<IRecipeService>();
        }

        [Fact]
        public void GetRecipes_Success()
        {
            //Arrange
            List<RecipeDto> fakeList = new List<RecipeDto>();
            _recipeService.Setup(c => c.GetRecipes(1, 25, "")).Returns(fakeList);
            RecipeController recipeController = new RecipeController(_recipeService.Object);

            //Act
            var result = recipeController.Get(new Paging {Size = 1, Page = 25, Uid = ""});
            var okresult = result as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, okresult.StatusCode);
        }

        [Fact]
        public void GetRecipes_Failed()
        {
            //Arrange
            _recipeService.Setup(c => c.GetRecipes(25, 1)).Returns((List<RecipeDto>) null);
            RecipeController recipeController = new RecipeController(_recipeService.Object);

            //Act
            var result = recipeController.Get(new Paging {Size = 25, Page = 1});
            var notFoundResult = result as NotFoundResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public void GetSpecificRecipe_Success()
        {
            //Arrange
            Recipe recipe = new Recipe();
            _recipeService.Setup(c => c.GetRecipe(Guid.Empty)).Returns(recipe);
            RecipeController recipeController = new RecipeController(_recipeService.Object);

            //Act
            var result = recipeController.Get(Guid.Empty);
            var okObjectResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, okObjectResult.StatusCode);
        }
        
        [Fact]
        public void GetSpecificRecipe_Failed()
        {
            //Arrange
            _recipeService.Setup(c => c.GetRecipe(Guid.Empty)).Returns((Recipe)null);
            RecipeController recipeController = new RecipeController(_recipeService.Object);

            //Act
            var result = recipeController.Get(Guid.Empty);
            var notFoundResult = result as NotFoundResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}