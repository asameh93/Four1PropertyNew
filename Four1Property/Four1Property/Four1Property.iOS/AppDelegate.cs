﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Four1Property.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            SlideOverKit.iOS.SlideOverKit.Init();
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();
            Xamarin.FormsGoogleMaps.Init("AIzaSyB21fWQ5BtY71q3a6BxMHA27Mbh9rbj_Pk");
            Rg.Plugins.Popup.Popup.Init();
           /*Xamarin.FormsMaps.Init();
            CachedImageRenderer.Init();
            CarouselViewRenderer.Init();
            XLabs.Forms.XFormsAppiOS.Init();
            CarouselView.FormsPlugin.iOS.CarouselViewRenderer.Init();*/
            LoadApplication(new App());
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
