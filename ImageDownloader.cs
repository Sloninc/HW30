using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace HW30
{
    public class ImageDownloader
    {
        public async Task Download(string remoteUri, string fileName)
        {
			// Качаем картинку в текущую директорию
			var myWebClient = new WebClient();
			DownloadEventArgs downloadEventArgs = new DownloadEventArgs(remoteUri, fileName);
			if (DownloadStarted != null)
				DownloadStarted(this, downloadEventArgs);
			await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
			if(DownloadCompleted != null)
				DownloadCompleted(this, downloadEventArgs);
			
		}
		public event EventHandler<DownloadEventArgs>? DownloadCompleted;
		public event EventHandler<DownloadEventArgs>? DownloadStarted;
    }
}
