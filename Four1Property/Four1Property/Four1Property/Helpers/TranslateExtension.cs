using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Four1Property.Helpers
{
    [Xamarin.Forms.ContentProperty("Text")]
    class TranslateExtension : Xamarin.Forms.Xaml.IMarkupExtension
    {
        const string ResourceId = "Four1Property.Resources.Resource";
        public string Text { get; set; }
        static readonly Lazy<System.Resources.ResourceManager> resmgr = new Lazy<System.Resources.ResourceManager>(() => new System.Resources.ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            var ci = Plugin.Multilingual.CrossMultilingual.Current.CurrentCultureInfo;

            var translation = resmgr.Value.GetString(Text, ci);

            if (translation == null)
            {

#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
#else
				translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
        public static string Translate(string text)
        {
            if (text == null)
                return "";

            var ci = Plugin.Multilingual.CrossMultilingual.Current.CurrentCultureInfo;

            var translation = resmgr.Value.GetString(text, ci);

            if (translation == null)
            {

#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", text, ResourceId, ci.Name),
                    "Text");
#else
				translation = text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
