using System.Net;
using System.IO;
namespace HW30_5
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
            Task[] tasks = new Task[10];
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            for (var i = 0; i < 10; i++)
            {
                string image = $"bigimage_#{i + 1}.jpg";
                string uri = remoteUri[i];
                using (WebClient webClient = new WebClient())
                {
                    tasks[i] = Task.Run(async () => 
                    { 
                        token.Register(() => webClient.CancelAsync()); 
                        await webClient.DownloadFileTaskAsync(uri, image); 
                    }, token);
                }
            }
            while (true)
            {
                Console.WriteLine("Нажмите клавишу A для остановки скачивания или " +
                    "любую другую клавишу для проверки статусов скачивания");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.KeyChar == 'a')
                {
                    Console.Clear();
                    cancelTokenSource.Cancel();
                    cancelTokenSource.Dispose();
                    Console.WriteLine("Операция прервана.");
                    Task.Delay(2000).Wait();
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            File.Delete($"bigimage_#{i + 1}.jpg");
                        }
                        catch (IOException)
                        {
                            while (true)
                            {
                                if (tasks[i].IsCanceled)
                                {
                                    File.Delete($"bigimage_#{i + 1}.jpg");
                                    break;
                                }
                            }
                        }
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    for (int i = 0; i < tasks.Length; i++)
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
    }
}