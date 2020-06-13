using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Four1Property.Renders
{
    public class CustomWebView : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(propertyName: "Uri",
                returnType: typeof(string),
                declaringType: typeof(CustomWebView),
                defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }


        public static readonly BindableProperty KillProperty = BindableProperty.Create(propertyName: "Kill",
                returnType: typeof(bool),
                declaringType: typeof(CustomWebView),
                defaultValue: default(bool));

        public bool Kill
        {
            get { return (bool)GetValue(KillProperty); }
            set { SetValue(KillProperty, value); }
        }
    }
}
