using System;
using System.IO;
using Four1Property.Services;
using Xamarin.Forms;
[assembly: Dependency(typeof(Four1Property.iOS.Services.FileManagerService))]
namespace Four1Property.iOS.Services
{
    public class FileManagerService : IFileManager
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);
        }
    }
}