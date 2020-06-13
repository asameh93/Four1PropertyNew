using Four1Property.Views;
using Four1Property.Views.Customer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Four1Property
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();
                string languageName = Helpers.Settings.Language;
                Plugin.Multilingual.CrossMultilingual.Current.CurrentCultureInfo = new System.Globalization.CultureInfo(languageName);
                Plugin.Multilingual.CrossMultilingual.Current.CurrentCultureInfo.NumberFormat = new System.Globalization.CultureInfo("en").NumberFormat;
                Plugin.Multilingual.CrossMultilingual.Current.CurrentCultureInfo.DateTimeFormat = new System.Globalization.CultureInfo("en").DateTimeFormat;
                if (Device.RuntimePlatform == Device.iOS)
                {
                    (DependencyService.Get<Services.ILocalize>()).SetLocale(languageName);
                }
                MainPage = new LoginPage();
            }
            catch (System.Exception)
            {
            }
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
