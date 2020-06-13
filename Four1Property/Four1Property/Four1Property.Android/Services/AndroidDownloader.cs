using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Four1Property.Droid.Services;
using Four1Property.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDownloader))]
namespace Four1Property.Droid.Services
{
    public class AndroidDownloader : IDownloader
    {
        int count = 0;
        public event EventHandler OnFileDownloaded;
        public void DownloadFile(string url, string folder)
        {
            try
            {
                string pathToNewFolder = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, folder);
                Directory.CreateDirectory(pathToNewFolder);

                try
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    string pathToNewFile = Path.Combine(pathToNewFolder,Path.GetFileName(url));
                    webClient.DownloadFileAsync(new Uri(url), pathToNewFile);
                    count++;
                }
                catch (Exception ex)
                {
                    if (OnFileDownloaded != null)
                        OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));
                    string error = ex.Message;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));
            }
            else
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(true));
            }
        }
    }
}