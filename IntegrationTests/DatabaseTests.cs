using DataAccessLayer;
using DataTransferObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace IntegrationTests
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
                Picture = ImagetoByteArray(@"C:\Users\Bartek\Downloads\zupa-pomidorowa.jpg")
            };
            database.AddRecipe(newRecipe);
            List<RecipeSimplifiedDto> list = database.GetRecipeList();
            foreach (RecipeSimplifiedDto r in list)
                if (r.Name == "Test")
                    return;
            Debug.WriteLine("Check connection: " + factory.GetConnectionString());
            Assert.Fail();
        }

        private byte[] ImagetoByteArray(string path)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(path);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        [Test]
        public void DeleteRecipeTest()
        {
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();
            database.DeleteRecipe("Test");
            List<RecipeSimplifiedDto> list = database.GetRecipeList();
            foreach (RecipeSimplifiedDto r in list)
                if (r.Name == "Test")
                    Assert.Fail();
        }

        [Test]
        public void GetRecipeTest()
        {
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();
            var r = database.GetRecipe(1);
            if (r.Ingredients == null)
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
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();

            var item = new IngredientDto()
            {
                Amount = 3,
                IngredientName = "test",
                Unit = "test"
            };

            database.AddShopListItem("db1500c7-f616-45d3-8069-14a9f264f2fa", item);
        }

        [Test]
        public void DeleteShopListItem()
        {
            IDataAccessObjectFactory factory = DatabaseFactory.GetInstance();
            IDataAccessObject database = factory.GetDao();

            database.DeleteShopListItem("db1500c7-f616-45d3-8069-14a9f264f2fa", "toDelete");
        }
    }
}