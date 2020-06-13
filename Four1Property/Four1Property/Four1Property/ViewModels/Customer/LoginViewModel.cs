using Four1Property.Models;
using Four1Property.Services;
using Four1Property.Views;
using Four1Property.Views.Customer;
using System;
using System.Collections.Generic;
using System.Text;
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

        private void Login(object obj)
        {
            try
            {
                if(!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                {
                    if(ValidationServices.EmailValidation(Email))
                    {
                        var result = ApiService.GetOneWithoutData<string>("properties", "LoginMobile/?email=" + Email + "&password=" + Password);
                        if (result != null)
                        {
                            if(result.Equals("InvalidPassword"))
                            {
                                Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Invalid Password", Plugin.Toast.Abstractions.ToastLength.Long);
                            }
                            else
                            {
                                App.Current.MainPage = new Home();
                                Plugin.Toast.CrossToastPopUp.Current.ShowToastSuccess("Login Successfully", Plugin.Toast.Abstractions.ToastLength.Long);
                            }
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
