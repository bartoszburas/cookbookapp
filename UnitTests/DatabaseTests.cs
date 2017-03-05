using DataAccessLayer;
using DataTransferObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace UnitTests
{
    /// <summary>
    ///     Database tests change the state of database. These are not tests with mocked data! 
    /// </summary>
    [TestFixture]
    public class DatabaseTests
    {

        [Test]
        public void AddRecipeTest()
        {
            Database database = new Database();
            RecipeDto newRecipe = new RecipeDto()
            {
                Amount = 2,
                Name = "Test",
                PreparationDescription = "DescriptionTest",
                PreparationTime = new TimeSpan(0, 20, 0),
                SkillLevel = "Begginer",
                Ingredients = new List<IngredientDto>()
                {
                    new IngredientDto() { Amount = 2, IngredientName = "IngredientTest", Unit = "UnitTest"},
                    new IngredientDto() { Amount = 2, IngredientName = "IngredientTest2", Unit = "UnitTest"}
                }
            };
            database.AddRecipe(newRecipe);
            List<RecipeSimplifiedDto> list = database.GetRecipeList();
            foreach (RecipeSimplifiedDto r in list)
                if (r.Name == "Test")
                    return;
            Assert.Fail();
        }

        [Test]
        public void DeleteRecipeTest()
        {
            Database database = new Database();
            database.DeleteRecipe("Test");
            List<RecipeSimplifiedDto> list = database.GetRecipeList();
            foreach (RecipeSimplifiedDto r in list)
                if (r.Name == "Test")
                    Assert.Fail();
        }

        [Test]
        public void GetRecipeTest()
        {
            Database database = new Database();
            var r = database.GetRecipe(1);
            if (r.Ingredients == null)
                Assert.Fail();
        }

        [Test]
        public void GetRecipeListTest()
        {
            var database = new Database();

            try
            {
                database.GetRecipeList();
            }
            catch (Exception)
            {
                SendEmailToDatabaseAdmin();
                Assert.Fail();
            }
        }

        private void SendEmailToDatabaseAdmin()
        {
            var fromAddress = new MailAddress("test387409275894985@gmail.com", "CookBookNotification");
            var toAddress = new MailAddress("test387409275894985@gmail.com", "CookBookNotification");
            const string fromPassword = "testpass";
            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Host = "smtp.gmail.com",
                EnableSsl = true
            };


            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Error in cookbook Database",
                Body = "Connecting to cookbook database failed when tried to get recipe list."
            })
            {
                client.Send(message);
            }
        }
    }
}