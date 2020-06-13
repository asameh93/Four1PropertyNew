using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Four1Property.Droid.Renders;
using Four1Property.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CornerStackLayout), typeof(RoundedStackLayout))]
namespace Four1Property.Droid.Renders
{
    public class RoundedStackLayout : ViewRenderer
    {
        Android.Views.View views;

        public RoundedStackLayout(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null)
            {
                views = new Android.Views.View(Context);
                //myAutoCompleteView.
                SetNativeControl(views);
            }
            if (e.NewElement != null)
            {
                var view = (CornerStackLayout)Element;
                if (view.IsCurvedCornersEnabled)
                {
                    // creating gradient drawable for the curved background  
                    var _gradientBackground = new GradientDrawable();
                    _gradientBackground.SetShape(ShapeType.Rectangle);
                    _gradientBackground.SetColor(view.BackColor.ToAndroid());
                    //_gradientBackground.SetColor(Android.Graphics.Color.Black);
                    // Thickness of the stroke line  
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());
                    // Radius for the curves  
                    _gradientBackground.SetCornerRadius(
                        DpToPixels(this.Context, Convert.ToSingle(view.CornerRadius)));
                    // set the background of the   
                    Control.SetBackground(_gradientBackground);
                }
                // Set padding for the internal text from border  
                Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingTop,
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom);
            }
        }
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}