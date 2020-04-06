using AutoMapper;
using RecipeManager.API.Application.Dtos;
using RecipeManager.API.Domain.Entities;

namespace RecipeManager.API.Infrastructure.AutomapperConfigurations
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>();
        }
    }
}