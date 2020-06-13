using System;
using Android.Content;
using Android.Graphics.Drawables;
using Four1Property.Droid.Renders;
using Four1Property.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(BorderCustomEntry), (typeof(borderCustomEntry)))]
namespace Four1Property.Droid.Renders
{
    public class borderCustomEntry : EntryRenderer
    {
        BorderCustomEntry element;
        public borderCustomEntry(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            try
            {
                if (e.OldElement == null)
                {
                    element = Element as BorderCustomEntry;
                    var gradientDrawable = new GradientDrawable();
                    gradientDrawable.SetCornerRadius(element.CornerRadius);
                    gradientDrawable.SetStroke(5, element.BorderColor.ToAndroid());
                    gradientDrawable.SetColor(Android.Graphics.Color.White);
                    Control.SetBackground(gradientDrawable);
                    Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}