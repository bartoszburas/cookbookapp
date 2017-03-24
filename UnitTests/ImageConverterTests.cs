using NUnit.Framework;
using System.IO;
using CookbookApp;
using System;

namespace UnitTests
{
    [TestFixture]
    class ImageConverterTests
    {
        [Test]
        public void ConvertFromImageToBinaryTest()
        {
            byte[] result = 
                ImageConverter.ImagetoByteArray("C:\\Users\\Bartek\\Downloads\\chicken-vegetable-noodle-soup.jpg");
            string firstByte = Convert.ToString(result[0], 16);
            string secondByte = Convert.ToString(result[1], 16);

            if(firstByte != "ff" || secondByte != "d8")     // checking marker value in StartOfImage
                Assert.Fail();
        }
    }
}
