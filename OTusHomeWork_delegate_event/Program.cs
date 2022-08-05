using System;
using System.Net;

namespace OTusHomeWork_delegate_event
{
    public class Program
    {
        //private static event ImageStarted;
        private static void Main(string[] args)
        {
            var imageDownloader = new ImageDownloader();
            imageDownloader.imageStarted += ImageDownloader_imageStarted;
            imageDownloader.imageCompleted += ImageDownloader_imageCompleted;
            imageDownloader.Download();

            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadLine();
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