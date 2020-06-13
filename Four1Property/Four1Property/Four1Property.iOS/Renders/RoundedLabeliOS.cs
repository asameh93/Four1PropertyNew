using Four1Property.iOS.Renders;
using Four1Property.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedLabel), typeof(RoundedLabeliOS))]
namespace Four1Property.iOS.Renders
{
    public class RoundedLabeliOS : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var _xfViewReference = (RoundedLabel)Element;

                // Radius for the curves
                this.Layer.CornerRadius = (float)_xfViewReference.CurvedCornerRadius;

                this.Layer.BackgroundColor = _xfViewReference.CurvedBackgroundColor.ToCGColor();
            }
        }
    }
}