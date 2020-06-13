using Android.Content;
using Android.Graphics;
using Four1Property.Droid.Renders;
using Four1Property.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(UnderLineLabel), (typeof(UnderLineLabelAndroid)))]
namespace Four1Property.Droid.Renders
{
    public class UnderLineLabelAndroid : LabelRenderer
    {
        public UnderLineLabelAndroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element != null)
            {
                Control.PaintFlags = PaintFlags.UnderlineText;
            }
        }
    }
}