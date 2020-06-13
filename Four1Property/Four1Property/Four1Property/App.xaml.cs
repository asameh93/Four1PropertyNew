using Four1Property.Views.Customer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Four1Property
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
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
