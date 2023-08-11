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
		WebClient? client;
		public async Task Download(string remoteUri, string fileName)
		{
			// Качаем картинку в текущую директорию
			client = new WebClient();
			Task.Delay(8000).Wait();
			await client.DownloadFileTaskAsync(remoteUri, fileName);
		}
	}
}
