using CoreGraphics;
using Four1Property.iOS.Renders;
using Four1Property.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickeriOS))]
namespace Four1Property.iOS.Renders
{
    public class CustomPickeriOS : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                Control.Layer.CornerRadius = 5;
                Control.Layer.BorderWidth = 1;
                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;
                Control.Layer.BorderColor = Color.FromHex("#8a3b37").ToCGColor();
                Control.ClipsToBounds = true;
            }
        }
    }
}