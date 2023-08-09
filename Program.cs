namespace HW30
{
    public class Program
    {
        static async Task Main()
        {
            string remoteUri = "https://img3.wallspic.com/crops/4/2/2/3/7/173224/173224-sunset-blue-cloud-water-water_resources-7680x4320.jpg";
            string fileName = "bigimage.jpg";

            ImageDownloader imageDownloader = new ImageDownloader();
            imageDownloader.DownloadStarted += ImageDownloader_DownloadStarted;
            imageDownloader.DownloadCompleted += ImageDownloader_DownloadCompleted;
            await imageDownloader.Download(remoteUri,fileName);
 

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





