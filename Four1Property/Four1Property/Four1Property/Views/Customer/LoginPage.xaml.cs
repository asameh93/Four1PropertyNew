using Four1Property.ViewModels.Customer;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = new LoginViewModel();
            }
            catch (Exception)
            {
            }
        }

        async private void RegisterNow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
        private void GUEST_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Home());
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Password.IsPassword)
            {
                Password.IsPassword = false;
                ShowHide.Source = "HidePassword.png";
            }
            else
            {
                Password.IsPassword = true;
                ShowHide.Source = "ShowPassword2.png";
            }
        }
    }
}