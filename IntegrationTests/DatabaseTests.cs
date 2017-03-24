using DataAccessLayer;
using DataTransferObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using CookbookApp;

namespace IntegrationTests
{
    /// <summary>
    ///     Tests of integration with local database
    /// </summary>
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void AddRecipeTest()
        {
            // Arrange
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();
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
                },
                Picture = ImageConverter.ImagetoByteArray(@"C:\Users\Bartek\Downloads\zupa-pomidorowa.jpg")
            };

            // Act 
            database.AddRecipe(newRecipe);

            // Assert 
            List<RecipeSimplifiedDto> list = database.GetRecipeList();
            foreach (RecipeSimplifiedDto r in list)
                if (r.Name == "Test")
                {
                    // Cleanup and pass
                    database.DeleteRecipe("Test");
                    Assert.Pass();
                }

            Debug.WriteLine("Check connection: " + factory.GetConnectionString());
            Assert.Fail();
        }

        [Test]
        public void DeleteRecipeTest()
        {
            // Arrange 
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();
            database.AddRecipe(new RecipeDto()
            {
                Name = "Test",
                Amount = 0,
                PreparationDescription = "Preparation test",
                PreparationTime = TimeSpan.FromMinutes(30),
                SkillLevel = "Skill level test"
            });

            // Act 
            database.DeleteRecipe("Test");

            // Assert
            List<RecipeSimplifiedDto> list = database.GetRecipeList();
            foreach (RecipeSimplifiedDto r in list)
                if (r.Name == "Test")
                    Assert.Fail();
        }

        [Test]
        public void GetRecipeTest()
        {
            // Arrange 
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();
            var list = database.GetRecipeList();
            int id = list[0].IdRecipe;

            // Act
            var r = database.GetRecipe(id);
            if (r == null)
            {
                Debug.WriteLine("Check connection: " + factory.GetConnectionString());
                Assert.Fail();
            }
        }

        [Test]
        public void GetRecipeListTest()
        {
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();

            try
            {
                database.GetRecipeList();
            }
            catch (Exception)
            {
                Debug.WriteLine("Check connection: " + factory.GetConnectionString());
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

        [Test]
        public void GetShopList()
        {
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();

            var result = database.GetShopList("Test");
        }

        [Test]
        public void AddShopListItem()
        {
            // Arrage
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();

            var item = new IngredientDto()
            {
                Amount = 3,
                IngredientName = "Test",
                Unit = "Test"
            };

            // Act
            database.AddShopListItem("db1500c7-f616-45d3-8069-14a9f264f2fa", item);

            // Assert
            var list = database.GetShopList("db1500c7-f616-45d3-8069-14a9f264f2fa");
            foreach (var i in list)
                if (i.IngredientName == "Test")
                {
                    database.DeleteRecipe("Test");
                    Assert.Pass();
                }
            Assert.Fail();
        }

        [Test]
        public void DeleteShopListItem()
        {
            // Arrange
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();
            database.AddShopListItem("db1500c7-f616-45d3-8069-14a9f264f2fa", new IngredientDto()
            {
                IngredientName = "toDelete"
            });

            // Act
            database.DeleteShopListItem("db1500c7-f616-45d3-8069-14a9f264f2fa", "toDelete");

            // Assert
            var list = database.GetShopList("db1500c7-f616-45d3-8069-14a9f264f2fa");
            foreach (var i in list)
                if (i.IngredientName == "toDelete")
                    Assert.Fail();
            Assert.Pass();
        }
    }
}