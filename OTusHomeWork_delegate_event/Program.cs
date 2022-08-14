using System;
using System.Threading.Tasks;

namespace OTusHomeWork_delegate_event
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //var imageDownloader = new ImageDownloader();
            ImageDownloader.Started += ImageDownloader_Started;
            ImageDownloader.Completed += ImageDownloader_Completed;

            //imageDownloader.Started += ImageDownloader_Started;
            //imageDownloader.Completed += ImageDownloader_Completed;

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
        }
        public static void ImageDownloader_Completed()
        {
            Console.WriteLine("Скачивание файла закончилось");
        }

        public static void ImageDownloader_Started()
        {
            Console.WriteLine("Скачивание файла началось");
        }
    }
}