using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataTransferObjects
{
    public class RecipeSimplifiedDto
    {
        public int IdRecipe { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
    }
}
