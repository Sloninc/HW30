using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace HW30_1_3
{
    /// <summary>
    /// Класс для синхронного запуска скачивания картинки уведомления об этом.
    /// </summary>
    public class ImageDownloader
    {
        public void Download(string remoteUri, string fileName)
        {
            // Качаем картинку в текущую директорию
            WebClient? client = new WebClient();
            DownloadEventArgs downloadEventArgs = new DownloadEventArgs(remoteUri, fileName);
            if (DownloadStarted != null)
                DownloadStarted(this, downloadEventArgs);
            client.DownloadFile(remoteUri, fileName);
            if (DownloadCompleted != null)
                DownloadCompleted(this, downloadEventArgs);
        }
        public event EventHandler<DownloadEventArgs>? DownloadCompleted;
        public event EventHandler<DownloadEventArgs>? DownloadStarted;
    }
}
