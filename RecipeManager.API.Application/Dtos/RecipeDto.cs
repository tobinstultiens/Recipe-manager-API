using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeManager.API.Application.Dtos
{
    /// <summary>
    /// The recipe dto that only returns the information needed to get a brief glance about the recipe.
    /// </summary>
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public  string Description { get; set; }
        [Url]
        public string ImgLink { get; set; }
    }
}