using NUnit.Framework;
using System.IO;
using CookbookApp;

namespace UnitTests
{
    [TestFixture]
    class ImageConverterTests
    {
        // TODO
        [Test]
        public void ConvertFromBinaryToImageTest()
        {

        }

        public void ConvertFromImageToBinaryTest()
        {
            byte[] result = ImageConverter.ImagetoByteArray("test.jpeg");
            Assert.Fail(); // 
        }
    }
}
