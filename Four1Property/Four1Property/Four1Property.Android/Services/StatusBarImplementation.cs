using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Views;
using Four1Property.Droid.Services;
using Four1Property.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(StatusBarImplementation))]

namespace Four1Property.Droid.Services
{
	public class StatusBarImplementation : IStatusBar
	{

		WindowManagerFlags _originalFlags;

        #region IStatusBar implementation

        public void DestroyWebView()
        {
            try
            {
                var activity = (Activity)Forms.Context;
                if (activity != null)
                {
                    activity.Finish();
                    activity.Dispose();
                }
                else UserDialogs.Instance.Toast("Activity Null", TimeSpan.FromSeconds(5));
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                UserDialogs.Instance.Toast("Activity Null", TimeSpan.FromSeconds(5));
            }
        }

        [Obsolete]
        public void HideStatusBar()
		{
			var activity = (Activity)Forms.Context;
			var attrs = activity.Window.Attributes;
			_originalFlags = attrs.Flags;
			attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
			activity.Window.Attributes = attrs;
		}

		public void ShowStatusBar()
		{
			var activity = (Activity)Forms.Context;
			var attrs = activity.Window.Attributes;
			attrs.Flags = _originalFlags;
			activity.Window.Attributes = attrs;
		}

		#endregion
	}
}

