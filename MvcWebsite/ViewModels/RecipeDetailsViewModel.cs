using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebsiteClient.ViewModels
{
    public class RecipeDetailsViewModel
    {
        public RecipeDetailsViewModel(RecipeDto recipe)
        {
            IdRecipe = recipe.IdRecipe;
            Name = recipe.Name;
            IdRecipe = recipe.IdRecipe;
            PreparationTime = recipe.PreparationTime;
            SkillLevel = recipe.SkillLevel;
            Amount = recipe.Amount;
            Picture = recipe.Picture;           // TODO: use imageConverter from wpf project
            PreparationDescription = recipe.PreparationDescription;
            Ingredients = recipe.Ingredients;
        }
        public int IdRecipe { get; set; }
        public string Name { get; set; }
        public System.TimeSpan PreparationTime { get; set; }
        public string SkillLevel { get; set; }
        public int Amount { get; set; }
        public byte[] Picture { get; set; } = new byte[] { 0 };
        public string PreparationDescription { get; set; }
        public ICollection<IngredientDto> Ingredients { get; set; }
    }
}