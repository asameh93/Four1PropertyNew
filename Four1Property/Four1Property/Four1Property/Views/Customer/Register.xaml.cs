using Four1Property.ViewModels.Customer;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Four1Property.Views.Customer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            try
            {
                InitializeComponent();
                BindingContext = new RegisterViewModel();
            }
            catch (Exception)
            {
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("no upload", "picking a photo is not supported", "ok");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            var Stream = file.GetStream();
            if (file == null)
                return;
            AddPhoto.Source = ImageSource.FromStream(() => file.GetStream());
        }
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (PasswordEN.IsPassword)
            {
                PasswordEN.IsPassword = false;
                ShwoHide.Source = "HidePassword.png";
            }
            else
            {
                PasswordEN.IsPassword = true;
                ShwoHide.Source = "ShowPassword2.png";
            }
        }
    }
}