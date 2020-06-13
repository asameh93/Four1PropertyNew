using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Four1Property.iOS.Services;
using Four1Property.Services;
using ObjCRuntime;
using System.Runtime.InteropServices;
using System.Diagnostics;

[assembly: Xamarin.Forms.Dependency(typeof(Localize))]
namespace Four1Property.iOS.Services
{
    public class Localize : ILocalize
    {
        [DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        internal extern static IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector, UISemanticContentAttribute arg1);
        public void SetLocale(string Language)
        {
            try
            {
                if (Language == "ar")
                {
                    Selector selector = new Selector("setSemanticContentAttribute:");
                    IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, UISemanticContentAttribute.ForceRightToLeft);
                }
                else
                {
                    Selector selector = new Selector("setSemanticContentAttribute:");
                    IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, UISemanticContentAttribute.ForceLeftToRight);
                }
            }
            catch (Exception s)
            {
                Debug.WriteLine("failed to set layout...." + s.Message.ToString());
            }
        }
    }
}