using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW30
{
    public class DownloadEventArgs: EventArgs
    {
        private string? _remoteUri;
        private string? _fileName;
        public DownloadEventArgs(string? remoteUri, string? fileName)
        {
            _remoteUri = remoteUri;
            _fileName = fileName;
        }   
        public string? RemoteUri
        {
            get { return _remoteUri; }
        }
        public string? FileName 
        { 
            get { return _fileName; } 
        }
    }
}
