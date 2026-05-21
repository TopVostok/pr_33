using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace ChatStudents.Classes.Common
{
    public class BitmapFromArrayByte
    {
        /// <summary>
        /// Создание битмапы изображения из массива байт
        /// </summary>
        /// <param name="imageData">Массив байтов изображения</param>
        /// <returns>BitmapImage для отображения в WPF</returns>
        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            BitmapImage image = new BitmapImage();
            using (var stream = new MemoryStream(imageData))
            {
                stream.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = stream;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        /// <summary>
        /// Преобразование BitmapImage обратно в массив байтов
        /// </summary>
        /// <param name="bitmapImage">Изображение</param>
        /// <returns>Массив байтов</returns>
        public static byte[] BitmapImageToBytes(BitmapImage bitmapImage)
        {
            if (bitmapImage == null)
                return null;

            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
    }
}