using System.Net;
namespace HW30_4
{
    /// <summary>
    /// 4й пункт домашнего задания.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            string fileName = "bigimage.jpg";
            //Ссылка на картинку 8К.
            string remoteUri = "https://img3.wallspic.com/crops/2/9/8/1/7/171892/171892-sassi_di_matera-campania-southern_italy-altopiano_delle_murge-travel-7680x4320.jpg";
            ImageDownloader imageDownloader=new ImageDownloader();
            //Запускаем асинхронную загрузку картинки.
            Task task = Task.Run(async () =>
            {
                await imageDownloader.Download(remoteUri, fileName);
            });
            while (true)
            {
                Console.WriteLine("Нажмите клавишу A для выхода или " +
                    "любую другую клавишу для проверки статуса скачивания");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.KeyChar == 'a')
                    Environment.Exit(0);
                else
                {
                    Console.Clear();
                    //Вывод информации о состоянии загрузки картинки.
                    if (task.IsCompleted)
                        Console.WriteLine("состояние загрузки картинки - загружено");
                    else Console.WriteLine("состояние загрузки картинки - загружается");
                    Console.WriteLine(Environment.NewLine);
                }
            }
        }
    }
}