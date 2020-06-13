using System;

namespace Four1Property.Services
{
    public interface IDownloader
    {
        void DownloadFile(string url, string folder);
        event EventHandler OnFileDownloaded;
    }
}
