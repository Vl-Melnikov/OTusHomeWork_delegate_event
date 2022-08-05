using System;
using System.Net;

namespace OTusHomeWork_delegate_event
{
    public class ImageDownloader
    {
        public delegate void ImageCompleted();

        public delegate void ImageStarted();
        public event ImageCompleted imageCompleted;

        public event ImageStarted imageStarted;
        public void Download()
        {
            // Откуда будем качать
            string remoteUri = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
            // Как назовем файл на диске
            string fileName = "bigimage.jpg";

            // Качаем картинку в текущую директорию
            var myWebClient = new WebClient();
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);

            imageStarted?.Invoke();
            myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
            imageCompleted?.Invoke();

            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
        }

    }
}