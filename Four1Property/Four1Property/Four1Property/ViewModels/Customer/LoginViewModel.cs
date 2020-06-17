using Four1Property.Models;
using Four1Property.Services;
using Four1Property.Views;
using Four1Property.Views.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Four1Property.ViewModels.Customer
{
    public class LoginViewModel
    {
        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        

        public string Email { get; set; }
        public string Password { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(Register);
        }

        private async void Register()
        {
            try
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new Register());
            }
            catch (Exception)
            {
            }        
        }

        private async void Login(object obj)
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    // Connection to internet is available
                    if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                    {
                        if (ValidationServices.EmailValidation(Email))
                        {
                            var result = await ApiService.GetOneWithoutData<string>("properties", "LoginMobile/?email=" + Email + "&password=" + Password);
                            if (result != null)
                            {
                                if (result.Equals("InvalidPassword"))
                                {
                                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helper.TranslateExtension.Translate("InvalidPassword"), Plugin.Toast.Abstractions.ToastLength.Long);
                                }
                                else
                                {
                                    App.Token = result;
                                    App.Email = Email;
                                    App.Current.MainPage = new MainPage();
                                    Plugin.Toast.CrossToastPopUp.Current.ShowToastSuccess(Helper.TranslateExtension.Translate("LoginSuccess"), Plugin.Toast.Abstractions.ToastLength.Long);
                                }
                            }
                            else
                            {
                                Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helper.TranslateExtension.Translate("ErrorCredentials"), Plugin.Toast.Abstractions.ToastLength.Long);
                            }
                        }
                        else
                        {
                           Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helper.TranslateExtension.Translate("ValidEmail"), Plugin.Toast.Abstractions.ToastLength.Long);
                        }
                    }
                    else
                    {
                        Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helper.TranslateExtension.Translate("EnterAllFields"), Plugin.Toast.Abstractions.ToastLength.Long);
                    }
                }
                else
                {
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helper.TranslateExtension.Translate("Msg_ConnectionError"), Plugin.Toast.Abstractions.ToastLength.Long);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
