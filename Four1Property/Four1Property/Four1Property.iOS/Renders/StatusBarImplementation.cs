using Four1Property.iOS.Renders;
using Four1Property.Services;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarImplementation))]

namespace Four1Property.iOS.Renders
{
    public class StatusBarImplementation : IStatusBar
    {

        #region IStatusBar implementation

        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }

        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }

        #endregion
    }
}
