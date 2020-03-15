using System;

namespace RecipeManager.Domain.Entities
{
    public class Direction
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
    }
}