using Android.App;
using Four1Property.Droid.Services;
using Four1Property.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(CloseApplication))]
namespace Four1Property.Droid.Services
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            var activity = (Activity)Forms.Context;
            activity.Finish();
        }
    }
}