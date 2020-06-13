using Xamarin.Forms;

namespace Four1Property.Services
{
    public class FileManagerService
    {
        /// <summary>
        /// get file path over all platform ios and android
        /// </summary>
        /// <param name="foldername"></param>
        /// <returns>string path of file</returns>
        public static string GetFilePath(string foldername)
        {
            return DependencyService.Get<IFileManager>().GetLocalFilePath(foldername);
        }
    }
    /// <summary>
    /// interface to control file manager 
    /// </summary>
    public interface IFileManager
    {
        string GetLocalFilePath(string foldername);
    }
}
