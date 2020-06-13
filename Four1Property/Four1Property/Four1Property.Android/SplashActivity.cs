using Android.App;
using Android.Support.V7.App;
using Four1Property.Droid;

namespace Four1Property.Droid
{
	[Activity(Label = "Four1Property", Icon = "@drawable/logo1", Theme = "@style/splashscreen",
			  MainLauncher = true, NoHistory = true)]
	public class SplashActivity : AppCompatActivity
	{
		protected override void OnResume()
		{
			base.OnResume();
			StartActivity(typeof(MainActivity));
			Finish();
		}
	}
}
