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

        private async void Register(object obj)
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
                            var result = await ApiService.GetOneWithoutData<string>("properties", "SignupMobile/?email=" + Email +
                                                                                    "&password=" + Password + "&number=" + PhoneNumber);
                            if (result != null)
                            {
                                App.Token = result;
                                App.Email = Email;
                                App.Current.MainPage = new MainPage();
                                Plugin.Toast.CrossToastPopUp.Current.ShowToastSuccess(Helper.TranslateExtension.Translate("RegisterSuccess"), Plugin.Toast.Abstractions.ToastLength.Long);
                            }
                            else
                            {
                                Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helper.TranslateExtension.Translate("ErrorHappen"), Plugin.Toast.Abstractions.ToastLength.Long);
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
