using System;
using System.Net;
using System.Threading.Tasks;

namespace OTusHomeWork_delegate_event
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            
            var imageDownloader = new ImageDownloader();
            imageDownloader.imageStarted += ImageDownloader_imageStarted;
            imageDownloader.imageCompleted += ImageDownloader_imageCompleted;
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

        private static void ImageDownloader_imageCompleted()
        {
            Console.WriteLine("Скачивание файла закончилось");
        }

        private static void ImageDownloader_imageStarted()
        {
            Console.WriteLine("Скачивание файла началось");
        }
    }
}
/*
 * сделаны 1-3
 * https://otus.ru/learning/168620/
 */