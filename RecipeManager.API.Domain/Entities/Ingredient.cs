using System;

namespace RecipeManager.API.Domain.Entities
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public int Measurement { get; set; }
        public string MeasurementType { get; set; }
        public string IngredientDescription { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}