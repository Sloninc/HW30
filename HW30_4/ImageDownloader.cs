using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace HW30_4
{
    public class ImageDownloader
    {
        public async Task Download(string remoteUri, string fileName)
        {
            // Качаем картинку в текущую директорию
            using (WebClient webClient = new WebClient())
            {
                await webClient.DownloadFileTaskAsync(remoteUri, fileName);
            }
        }
    }
}
