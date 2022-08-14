using System;
using System.Net;
using System.Threading.Tasks;

namespace OTusHomeWork_delegate_event
{
    class Program
    {
        public static void Main(string[] args)
        {
            var imageDownloader = new ImageDownloader();

            imageDownloader.Started += ImageDownloader_Started;
            imageDownloader.Completed += ImageDownloader_Completed;

            Task task = ImageDownloader.Download();

            Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");

            var finish = "";
            while (finish != "A")
            {
                finish = Console.ReadLine();
                var status = task.IsCompleted ? "Загружена" : "Не загружена";
                Console.WriteLine(status);
            }
            Console.WriteLine("Выполнение завершено");
            return;
        }

        private static void ImageDownloader_Completed()
        {
            Console.WriteLine("Скачивание файла закончилось");
        }

        private static void ImageDownloader_Started()
        {
            Console.WriteLine("Скачивание файла началось");
        }
    }

    public class ImageDownloader
    {
        public delegate void imageCompleted();
        public delegate void imageStarted();

        public event imageCompleted Completed;
        public event imageStarted Started;

        public async static Task Download()
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