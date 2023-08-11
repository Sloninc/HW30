using System.Diagnostics;
using System.IO;
namespace HW30_1_3
{
    public class Program
    {
        static async Task Main()
        {
            string fileName = "bigimage.jpg";
            string remoteUri = "https://img3.wallspic.com/crops/2/9/8/1/7/171892/171892-sassi_di_matera-campania-southern_italy-altopiano_delle_murge-travel-7680x4320.jpg";
            ImageDownloader imageDownloader = new ImageDownloader();
            imageDownloader.DownloadStarted += ImageDownloader_DownloadStarted;
            imageDownloader.DownloadCompleted += ImageDownloader_DownloadCompleted;
            Task task = Task.Run(() => imageDownloader.Download(remoteUri, fileName));
            while (true)
            {
                Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.KeyChar == 'a')
                    Environment.Exit(0);
                else
                {
                    Console.Clear();
                    if (task.IsCompleted)
                        Console.WriteLine("состояние загрузки картинки - загружено");
                    else Console.WriteLine("состояние загрузки картинки - загружается");
                    Console.WriteLine(Environment.NewLine);
                }
            }
        }

        private static void ImageDownloader_DownloadCompleted(object? sender, DownloadEventArgs e)
        {
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", e.FileName, e.RemoteUri);
        }

        private static void ImageDownloader_DownloadStarted(object? sender, DownloadEventArgs e)
        {
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", e.FileName, e.RemoteUri);
        }
    }
}