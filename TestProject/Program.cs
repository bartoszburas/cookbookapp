using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObjects;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();

            RecipeDto rdto = db.GetRecipe(1);

            Console.WriteLine(rdto.Name);
            
            Console.ReadKey();
        }
    }
}
