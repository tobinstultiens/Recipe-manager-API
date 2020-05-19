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
    public class RecipeContrllerTest
    {
        private AutoMocker _mocker;
        private readonly ILogger<RecipeService> _logger;
        private readonly Mock<IMapper> _mapper;

        public RecipeContrllerTest()
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

            //Act

            //Assert
        }
    }
}