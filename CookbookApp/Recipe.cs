using DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Media;

namespace CookbookApp
{
    public class Recipe
    {
        public int IdRecipe { get; set; }
        public string Name { get; set; }
        public System.TimeSpan PreparationTime { get; set; }
        public string SkillLevel { get; set; }
        public int Amount { get; set; }
        public ImageSource Picture { get; set; }
        public string Preparation { get; set; }
        public ICollection<IngredientDto> Ingredients { get; set; }
    }
}