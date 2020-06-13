using Four1Property.Services;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(Four1Property.iOS.Services.CloseApplication))]
namespace Four1Property.iOS.Services
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            Thread.CurrentThread.Abort();
        }
    }
}