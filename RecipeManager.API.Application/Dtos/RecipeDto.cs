using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeManager.API.Application.Dtos
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public  string Description { get; set; }
        [Url]
        public string ImgLink { get; set; }
    }
}