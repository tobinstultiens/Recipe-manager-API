using System;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Moq.AutoMock;
using RecipeManager.API.Application.Services;
using RecipeManager.API.Domain.Entities;
using RecipeManager.API.Persistence.EntityFramework;
using RecipeManager.API.Persistence.EntityFramework.Contexts;
using Xunit;
using ILogger = NLog.ILogger;

namespace RecipeManager.API.Tests
{
    public class RecipeServiceTest
    {
        private AutoMocker _mocker;
        private ILogger<RecipeService> _logger;
        private Mock<IMapper> _mapper;

        public RecipeServiceTest()
        {
            //Arrange
            _mocker = new AutoMocker();
            _logger = new Logger<RecipeService>(new NullLoggerFactory());
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public void GetRecipe_Success()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var recipe = new Recipe();
            mockUnitOfWork.Setup(work => work.RecipeRepository.GetById("8008c1a4-2bd2-40c4-8bb9-f0399db32456"))
                .Returns(recipe);
            var recipeService = new RecipeService(mockUnitOfWork.Object, _logger, _mapper.Object);

            //Act
            var result = recipeService.GetRecipe(new Guid("8008c1a4-2bd2-40c4-8bb9-f0399db32456"));

            //Assert
            Assert.Equal(recipe,result);
        }
    }
}