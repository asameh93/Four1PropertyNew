using System;
using Four1Property.iOS.Renders;
using Four1Property.Renders;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderCustomEntry), (typeof(borderCustomEntry)))]
namespace Four1Property.iOS.Renders
{
    public class borderCustomEntry : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var view = (BorderCustomEntry)Element;

                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
                Control.LeftViewMode = UITextFieldViewMode.Always;

                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;

                // Radius for the curves  
                Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);

                // Thickness of the Border Color  
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();

                // Thickness of the Border Width  
                //Control.Layer.BorderWidth = view.BorderWidth;
                Control.Layer.BorderWidth = 1;

                Control.ClipsToBounds = true;
            }
        }
    }
}