using AutoMapper;
using RecipeManager.API.Application.Dtos;
using RecipeManager.API.Domain.Entities;

namespace RecipeManager.API.Infrastructure.AutomapperConfigurations
{
    /// <summary>
    /// This maps the recipe profile with their DTOs
    /// </summary>
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>();
        }
    }
}