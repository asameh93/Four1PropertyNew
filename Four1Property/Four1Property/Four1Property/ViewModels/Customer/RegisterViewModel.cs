using Four1Property.Services;
using Four1Property.Views;
using System;
using System.Collections.Generic;
using System.Text;
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
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(PhoneNumber))
                {
                    if(ValidationServices.EmailValidation(Email))
                    {
                        var result = ApiService.GetOneWithoutData<string>("properties", "SignupMobile/?email=" + Email +
                                                                          "&password=" + Password+ "&number="+ PhoneNumber);
                        if (result != null)
                        {
                            App.Current.MainPage = new Home();
                            Plugin.Toast.CrossToastPopUp.Current.ShowToastSuccess("Login Successfully", Plugin.Toast.Abstractions.ToastLength.Long);
                        }
                        else
                        {
                            Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Error Credentials", Plugin.Toast.Abstractions.ToastLength.Long);
                        }
                    }
                    else
                    {
                        Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Enter Valid Email", Plugin.Toast.Abstractions.ToastLength.Long);
                    }
                }
                else
                {
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Enter All Fields", Plugin.Toast.Abstractions.ToastLength.Long);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
