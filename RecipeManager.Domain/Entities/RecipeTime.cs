using System;

namespace RecipeManager.Domain.Entities
{
    public class RecipeTime
    {
        public Guid Id { get; set; }
        public string PrepTime { get; set; }
        public string CookTime { get; set; }
        public string TotalTime { get; set; }
    }
}