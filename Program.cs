using System.Diagnostics;
namespace HW30
{
    public class Program
    {
        static async Task Main()
        {
            string[] remoteUri =
            {
                "https://img3.wallspic.com/crops/4/2/2/3/7/173224/173224-sunset-blue-cloud-water-water_resources-7680x4320.jpg",
                "https://img3.wallspic.com/crops/6/5/0/4/7/174056/174056-jasper_national_park_of_canada-road-forest_highway-highway-cloud-7680x4320.jpg",
                "https://img3.wallspic.com/crops/5/7/7/3/7/173775/173775-winter-alps-france-canada-mountain-7680x4320.jpg",
                "https://img3.wallspic.com/crops/2/9/8/1/7/171892/171892-sassi_di_matera-campania-southern_italy-altopiano_delle_murge-travel-7680x4320.jpg",
                "https://img2.wallspic.com/crops/7/5/0/4/7/174057/174057-nature-marka_ev_renkli_kilim_blok_018-cloud-plant-mountain-7680x4320.jpg",
                "https://img2.wallspic.com/crops/4/4/4/3/7/173444/173444-mountain-landscape-nature-cloud-atmosphere-7680x4320.jpg",
                "https://img3.wallspic.com/crops/3/4/4/3/7/173443/173443-ubuntu_minimalist-ubuntu-minimalism-colored-linkin_park-7680x4320.jpg",
                "https://img2.wallspic.com/crops/5/3/0/1/7/171035/171035-joshua_tree_national_park-joshua_tree-landscape-plant-cloud-7680x4320.jpg",
                "https://img1.wallspic.com/crops/4/4/0/3/7/173044/173044-glacier-perito_moreno_glacier-glacial_lake-fjord-iceberg-7680x4320.jpg",
                "https://img1.wallspic.com/crops/9/9/5/2/7/172599/172599-banff_national_park-moraine_lake-nature-national_park-banff-7680x4320.jpg"
            };

            //string fileName = "bigimage.jpg";

            //ImageDownloader imageDownloader = new ImageDownloader();
            //imageDownloader.DownloadStarted += ImageDownloader_DownloadStarted;
            //imageDownloader.DownloadCompleted += ImageDownloader_DownloadCompleted;
            //Task task = Task.Run(() => imageDownloader.Download(remoteUri, fileName));
            //while (true)
            //{
            //    Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
            //    ConsoleKeyInfo consoleKey = Console.ReadKey();
            //    if (consoleKey.KeyChar == 'a')
            //        Environment.Exit(0);
            //    else
            //    {
            //        Console.Clear();
            //        if (task.IsCompleted)
            //            Console.WriteLine("состояние загрузки картинки - загружено");
            //        else Console.WriteLine("состояние загрузки картинки - загружается");
            //        Console.WriteLine(Environment.NewLine);
            //    }
            //}
            Task[] tasks = new Task[10];
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            for (var i = 0; i < 10; i++)
            {
                string image = $"bigimage_#{i+1}.jpg";
                string uri = remoteUri[i];
                ImageDownloader imageDownloader = new ImageDownloader();
                tasks[i] = Task.Run(() =>
                {
                    //Console.WriteLine("Скачивание "+image);
                    Task.Delay(10000).Wait();
                    if (token.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
                    {
                        Console.WriteLine($"Скачивание "+image+" прервано");
                        return;     //  выходим из метода и тем самым завершаем задачу
                    }
                    imageDownloader.Download(uri, image);
                }, token);
                //tasks[i].Start();   // запускаем задачу
            }
            //ParallelDownload(remoteUri, tasks, token);
            while (true)
            {
                Console.WriteLine("Нажмите клавишу A для остановки скачивания или любую другую клавишу для проверки статусов скачивания");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.KeyChar == 'a')
                {
                    cancelTokenSource.Cancel();
                    cancelTokenSource.Dispose();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    for(int i=0; i<tasks.Length; i++)
                    {
                        if (tasks[i].IsCompleted)
                            Console.WriteLine($"состояние загрузки картинки bigimage_#{i + 1}.jpg - загружено");
                        else Console.WriteLine($"состояние загрузки картинки bigimage_#{i + 1}.jpg - загружается");
                    }
                    Console.WriteLine(Environment.NewLine);
                }
            }
            Console.ReadLine();
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





