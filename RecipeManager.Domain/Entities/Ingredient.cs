using System;

namespace RecipeManager.Domain.Entities
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public int Measurement { get; set; }
        public string MeasurementType { get; set; }
        public string IngredientDescription { get; set; }
    }
}