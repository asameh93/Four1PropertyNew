using Four1Property.Services;
using Four1Property.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Four1Property.ViewModels.Customer
{
    public class RegisterViewModel
    {
        public Command RegisterCommand { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        
        public RegisterViewModel()
        {
            RegisterCommand = new Command(Register);
        }

        private void Register(object obj)
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(PhoneNumber))
                    {
                        if (ValidationServices.EmailValidation(Email))
                        {
                            var result = ApiService.GetOneWithoutData<string>("properties", "SignupMobile/?email=" + Email +
                                                                              "&password=" + Password + "&number=" + PhoneNumber);
                            if (result != null)
                            {
                                App.Current.MainPage = new Home();
                                Plugin.Toast.CrossToastPopUp.Current.ShowToastSuccess(Helpers.TranslateExtension.Translate("RegisterSuccess"), Plugin.Toast.Abstractions.ToastLength.Long);
                            }
                            else
                            {
                                Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helpers.TranslateExtension.Translate("ErrorHappen"), Plugin.Toast.Abstractions.ToastLength.Long);
                            }
                        }
                        else
                        {
                            Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helpers.TranslateExtension.Translate("ValidEmail"), Plugin.Toast.Abstractions.ToastLength.Long);
                        }
                    }
                    else
                    {
                        Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helpers.TranslateExtension.Translate("EnterAllFields"), Plugin.Toast.Abstractions.ToastLength.Long);
                    }
                }
                else
                {
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helpers.TranslateExtension.Translate("Msg_ConnectionError"), Plugin.Toast.Abstractions.ToastLength.Long);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
