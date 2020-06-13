using Android.Content;
using Android.Graphics.Drawables;
using Four1Property.Droid.Renders;
using Four1Property.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerAndroid))]
namespace Four1Property.Droid.Renders
{
    public class CustomPickerAndroid : PickerRenderer
    {
        public CustomPickerAndroid(Context context) : base(context)
        {
        }
        public static void Init() { }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(15);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.DimGray);
                gradientDrawable.SetColor(Android.Graphics.Color.White);
                Control.SetBackground(gradientDrawable);
                Control.SetPadding(40, 10, 40 , 10);
            }
        }
    }
}