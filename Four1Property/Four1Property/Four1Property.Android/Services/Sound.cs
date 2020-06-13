using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Support.V4.App;
using Four1Property.Droid.Services;
using Four1Property.Services;

[assembly: Xamarin.Forms.Dependency(typeof(Sound))]
namespace Four1Property.Droid.Services
{
    public class Sound : ISound
    {
        public void MakeSound()
        {
            try
            {
                Intent resultIntent = Application.Context.PackageManager.GetLaunchIntentForPackage(Application.Context.PackageName);

                var pending = PendingIntent.GetActivity(Application.Context, 0,
                              resultIntent, PendingIntentFlags.CancelCurrent);

                NotificationCompat.Builder builder = new NotificationCompat.Builder(Application.Context)
                    .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
                    .SetContentIntent(pending);

                var notification = builder.Build();
                NotificationManager manager = Application.Context.GetSystemService(Context.NotificationService) as NotificationManager;
                manager = NotificationManager.FromContext(Application.Context);
                manager.Notify(10010, notification);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
}