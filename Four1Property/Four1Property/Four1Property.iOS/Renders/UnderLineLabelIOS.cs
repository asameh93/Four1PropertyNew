using Foundation;
using UIKit;
using Four1Property.Renders;
using Four1Property.iOS.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(UnderLineLabel), typeof(UnderLineLabelIOS))]
namespace Four1Property.iOS.Renders
{
    public class UnderLineLabelIOS : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                if (e.NewElement != null)
                {
                    var label = (UnderLineLabel)this.Element;
                    this.Control.AttributedText = new NSAttributedString(label.Text, underlineStyle: NSUnderlineStyle.Single);
                    Control.TextColor = UIColor.Black;
                }
            }
        }
    }
}
