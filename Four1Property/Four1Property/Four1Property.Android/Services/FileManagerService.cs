using System.IO;
using Four1Property.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Four1Property.Droid.Services.FileManagerService))]
namespace Four1Property.Droid.Services
{
    public class FileManagerService : IFileManager
    {
        /// <summary> 
        /// get file path over all platform
        /// </summary>
        /// <param name="foldername"></param>
        /// <returns>string path of file</returns>

        public string GetLocalFilePath(string foldername)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, foldername);
        }
    }
}