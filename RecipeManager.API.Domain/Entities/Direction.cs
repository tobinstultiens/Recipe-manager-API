using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManager.API.Domain.Entities
{
    public class Direction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Order is necessary to know which direction you need to start with.")]
        public int Index { get; set; }
        [Required(ErrorMessage = "Description needed to explain the direction")]
        public string Description { get; set; }
        public Guid RecipeId { get; set; }
    }
}