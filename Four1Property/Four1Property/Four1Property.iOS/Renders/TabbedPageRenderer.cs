
using Xamarin.Forms;
using AUC.iOS.Renders;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Four1Property.Renders;

[assembly: ExportRenderer(typeof(MyTabbedPage), typeof(TabbedPageRenderer))]
namespace AUC.iOS.Renders
{
    public class TabbedPageRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            try
            {
                base.OnElementChanged(e);
                TabBar.TintColor = UIColor.FromRGB(138, 59, 55);
                TabBar.BarTintColor = UIColor.White;
                TabBar.UnselectedItemTintColor = UIColor.FromRGB(138, 59, 55);
            }
            catch (System.Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
}
