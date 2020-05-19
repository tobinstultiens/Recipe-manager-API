using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManager.API.Domain.Entities
{
    public class RecipeTime
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string PrepTime { get; set; }
        public string CookTime { get; set; }
        public string TotalTime { get; set; }
        public Guid RecipeId { get; set; }
    }
}