using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeManager.API.Domain.Entities
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "You can't have an ingredients without a measurement")]
        public int Measurement { get; set; }
        [Required(ErrorMessage = "Need to know what type of measurement")]
        public string MeasurementType { get; set; }
        [Required(ErrorMessage = "Description of the ingredients is necessary to know what ingredient you need")]
        public string IngredientDescription { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}