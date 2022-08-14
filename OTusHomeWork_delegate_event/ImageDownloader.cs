using System;
using System.Net;
using System.Threading.Tasks;

namespace OTusHomeWork_delegate_event
{
    public static class ImageDownloader
    {
        public delegate void ImageCompleted();
        public delegate void ImageStarted();

        public static event ImageCompleted Completed;
        public static event ImageStarted Started;

        public static async Task Download()
        {
            string remoteUri = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
            string fileName = "bigimage.jpg";

            WebClient myWebClient = new WebClient();
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);

            Started?.Invoke();
            await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
            Completed?.Invoke();

            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
        }
    }
}