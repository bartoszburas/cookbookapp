using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class RecipeDto
    {
        public int IdRecipe { get; set; }
        public string Name { get; set; }
        public System.TimeSpan PreparationTime { get; set; }
        public string SkillLevel { get; set; }
        public int Amount { get; set; }
        public byte[] Picture { get; set; } = new byte[] { 0 };
        public string PreparationDescription{ get; set; }
        public ICollection<IngredientDto> Ingredients { get; set; }
    }
}
