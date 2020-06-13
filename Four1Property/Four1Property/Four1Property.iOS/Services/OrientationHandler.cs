using Foundation;
using Four1Property.iOS.Services;
using Four1Property.Services;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(OrientationHandlerImplementation))]

namespace Four1Property.iOS.Services
{
    public class OrientationHandlerImplementation : IOrientationHandler
    {
        public void ForceLandscape()
        {
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeLeft), new NSString("orientation"));
        }

        public void ForcePortrait()
        {
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.Portrait), new NSString("orientation"));
        }
    }
}
