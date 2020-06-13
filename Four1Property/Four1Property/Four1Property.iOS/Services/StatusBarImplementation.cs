using System;
using Four1Property.iOS.Services;
using Four1Property.Services;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarImplementation))]
namespace Four1Property.iOS.Services
{
    public class StatusBarImplementation : IStatusBar
    {
        public void DestroyWebView()
        {
            try
            {
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
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
