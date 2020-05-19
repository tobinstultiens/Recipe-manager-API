using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManager.API.Domain.Entities
{
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "You can't have an ingredients without a measurement")]
        public int Measurement { get; set; }
        [Required(ErrorMessage = "Need to know what type of measurement")]
        public string MeasurementType { get; set; }
        [Required(ErrorMessage = "Description of the ingredients is necessary to know what ingredient you need")]
        public string IngredientDescription { get; set; }
        public Guid RecipeId { get; set; }
    }
}