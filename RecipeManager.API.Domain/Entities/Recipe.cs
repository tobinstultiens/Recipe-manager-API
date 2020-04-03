using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeManager.API.Domain.Entities
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Ingredients are needed for a recipe")]
        public List<Ingredient> Ingredients { get; set; }
        [Required(ErrorMessage = "Directions are needed to make the recipe properly")]
        public List<Direction> Directions { get; set; }
        public RecipeTime RecipeTime { get; set; }
        [Url]
        public string ImgLink { get; set; }
        [Url]
        public string VideoLink { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
    }
}