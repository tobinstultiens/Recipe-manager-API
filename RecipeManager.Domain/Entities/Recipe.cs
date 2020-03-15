﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeManager.Domain.Entities
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Direction> Directions { get; set; }
        public RecipeTime RecipeTime { get; set; }
        public string ImgLink { get; set; }
        public string VideoLink { get; set; }
    }
}
