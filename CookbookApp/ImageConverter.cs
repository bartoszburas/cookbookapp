using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CookbookApp.ServiceReference;

namespace CookbookApp
{
    class ImageConverter
    {
        public ImageSource ByteArrayToImage(byte[] byteArrayIn)
        {
            BitmapImage image = null;
            if (byteArrayIn != null)
            {
                MemoryStream stream = new MemoryStream(byteArrayIn);
                image = new BitmapImage();
                try
                {
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.EndInit();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return image;
        }

        public byte[] ImagetoByteArray(string path)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(path);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public List<Recipe> ConvertRecipeList(RecipeSimplifiedDto[] list)
        {
            List<Recipe> newList = new List<Recipe>();
            foreach (var recipe in list)
            {
                Recipe r = new Recipe()
                {
                    IdRecipe = recipe.IdRecipe,
                    Name = recipe.Name,
                    Picture = ByteArrayToImage(recipe.Picture)
                };

                newList.Add(r);
            }

            return newList;
        }

        public Recipe ConvertRecipe(RecipeDto recipe)
        {
            Recipe retVal = new Recipe()
            {
                Amount = recipe.Amount,
                IdRecipe = recipe.IdRecipe,
                Ingredients = recipe.RecipeIngredient,
                Name = recipe.Name,
                Picture = ByteArrayToImage(recipe.Picture),
                Preparation = recipe.PreparationDescription,
                PreparationTime = recipe.PreparationTime,
                SkillLevel = recipe.SkillLevel
            };

            return retVal;
        }
    }
}
