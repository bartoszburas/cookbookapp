using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObjects;
using System.IO;

namespace funProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Database d = new Database();

            System.Drawing.Image img = System.Drawing.Image.FromFile("pomidory-faszerowane-z-szynka.jpg");
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            RecipeDto newRecipe = new RecipeDto()
            {
                Amount = 4,
                Name = "Pomidory faszerowane z szynką",
                PreparationDescription = "Jajka ugotuj na twardo. Ostudź. Z pomidorów zetnij wierzch, wydrąż nasiona, delikatnie posól. Szynkę pokrój w kostkę. Jajka obierz ze skorupek i pokrój w kostkę. " +
                "Wymiesza składniki farszu z Majonezem. Dopraw solą i pieprzem, jeszcze raz wymieszaj. Napełniaj farszem pomidory. Możesz podawać na liściach sałaty, udekorowane koperkiem.",
                PreparationTime = new TimeSpan(0, 25, 0),
                SkillLevel = "Begginer",
                Picture = ms.ToArray(),
                Ingredients = new DataTransferObjects.IngredientDto[]
                {
                    new DataTransferObjects.IngredientDto() { Amount = 8, IngredientName = "pomidory średniej wielkości", Unit = "sztuk"},
                    new DataTransferObjects.IngredientDto() { Amount = 3, IngredientName = "Majonez Lekki WINIARY", Unit = "łyżki"},
                    new DataTransferObjects.IngredientDto() { Amount = 100, IngredientName = "szynka konserwowa", Unit = "g"},
                    new DataTransferObjects.IngredientDto() { Amount = 4, IngredientName = "jajka ", Unit = "sztuki"},
                    new DataTransferObjects.IngredientDto() { Amount = 2, IngredientName = "posiekana natka pietruszki", Unit = "łyżki"},
                    new DataTransferObjects.IngredientDto() { Amount = 2, IngredientName = "posiekany szczypiorek ", Unit = "łyżki"},
                    new DataTransferObjects.IngredientDto() { Amount = 2, IngredientName = "sól", Unit = "szczypty"},
                    new DataTransferObjects.IngredientDto() { Amount = 2, IngredientName = "pieprz", Unit = "szczypty"}
                }
            };

            d.AddRecipe(newRecipe);

            var r = d.GetRecipe(2011);
        }
    }
}
