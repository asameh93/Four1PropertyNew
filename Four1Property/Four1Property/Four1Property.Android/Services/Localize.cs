using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Four1Property.Droid.Services;
using Four1Property.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace Four1Property.Droid.Services
{
    public class Localize : ILocalize
    {
        public void SetLocale(string Language)
        {
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity.Recreate();
        }
    }
}