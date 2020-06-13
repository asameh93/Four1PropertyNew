using System;
using Android.App;
using Android.Content.PM;
using Four1Property.Droid.Services;
using Four1Property.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(OrientationHandler))]

namespace Four1Property.Droid.Services
{
	public class OrientationHandler : IOrientationHandler
	{
        [Obsolete]
        public void ForceLandscape()
		{
			((Activity)Forms.Context).RequestedOrientation = ScreenOrientation.Landscape;
		}

        [Obsolete]
        public void ForcePortrait()
		{
			((Activity)Forms.Context).RequestedOrientation = ScreenOrientation.Portrait;
		}
	}
}
