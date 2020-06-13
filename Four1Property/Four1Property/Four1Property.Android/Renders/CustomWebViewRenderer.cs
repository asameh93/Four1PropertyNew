using Android.Annotation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Webkit;
using Four1Property.Droid.Renders;
using Four1Property.Renders;
using Four1Property.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]

namespace Four1Property.Droid.Renders
{
    public class CustomWebViewRenderer : WebViewRenderer 
    {
        Activity mContext;

        public CustomWebViewRenderer(Context context) : base(context)
        {
            this.mContext = context as Activity;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            try
            {
                if(Control != null && e.NewElement != null)
                {
                    var customWebView = Element as CustomWebView;

                    Control.Settings.JavaScriptEnabled = true;
                    Control.Settings.AllowFileAccessFromFileURLs = true;
                    Control.ClearCache(true);
                    Control.Settings.SetAppCacheEnabled(false);
                    Control.Settings.CacheMode = CacheModes.NoCache;
                    Control.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
                    Control.Settings.MediaPlaybackRequiresUserGesture = true;

                    if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
                    {
                        Control.SetLayerType(Android.Views.LayerType.Hardware, null);
                    }
                    else
                    {
                        Control.SetLayerType(Android.Views.LayerType.Software, null);
                    }
                    Control.LoadUrl(customWebView.Uri);
                    Control.SetWebChromeClient(new MyWebClient(mContext));
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                base.OnElementPropertyChanged(sender, e);
                if (Control != null)
                {
                    var customWebView = Element as CustomWebView;
                    if (customWebView.Kill)
                        Control.Destroy();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        public class MyWebClient : WebChromeClient
        {
            Activity mContext;
            public MyWebClient(Activity context)
            {
                this.mContext = context;
            }
            [TargetApi(Value = 21)]
            public override void OnPermissionRequest(PermissionRequest request)
            {
                mContext.RunOnUiThread(() => {
                    request.Grant(request.GetResources());
                });
            }
        }
    }
}