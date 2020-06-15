﻿using Four1Property.Views.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Four1Property.ViewModels
{
    class LanguageVM : BaseViewModel
    {
        public LanguageVM()
        {
            try
            {
                string languageName = Helpers.Settings.Language;
                if (languageName == "en")
                {
                    Helpers.Settings.Language = languageName = "ar";
                }
                else
                {
                    Helpers.Settings.Language = languageName = "en";
                }
                (Xamarin.Forms.DependencyService.Get<Services.ILocalize>()).SetLocale(languageName);
                if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS)
                {
                    App.Current.MainPage = new LoginPage();
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}