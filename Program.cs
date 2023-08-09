using System.Diagnostics;
namespace HW30
{
    public class Program
    {
        static async Task Main()
        {
            string remoteUri = "https://img3.wallspic.com/crops/4/2/2/3/7/173224/173224-sunset-blue-cloud-water-water_resources-7680x4320.jpg";
            string fileName = "bigimage.jpg";

            ImageDownloader imageDownloader = new ImageDownloader();
            //imageDownloader.DownloadStarted += ImageDownloader_DownloadStarted;
            //imageDownloader.DownloadCompleted += ImageDownloader_DownloadCompleted;
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





