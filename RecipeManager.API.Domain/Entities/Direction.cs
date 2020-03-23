using System;

namespace RecipeManager.API.Domain.Entities
{
    public class Direction
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}