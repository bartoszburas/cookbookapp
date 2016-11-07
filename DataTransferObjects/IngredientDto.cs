using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class IngredientDto
    {
        public string IngredientName { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
    }
}
