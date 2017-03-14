using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace CookbookApp
{
    public class ImageConverter
    {
        public static ImageSource ByteArrayToImage(byte[] byteArrayIn)
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

        public static byte[] ImagetoByteArray(string filePath)
        {
            Image img = Image.FromFile(filePath);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
