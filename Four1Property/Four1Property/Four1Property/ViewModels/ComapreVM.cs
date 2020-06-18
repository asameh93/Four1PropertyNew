using System;
using Acr.UserDialogs;
using Four1Property.Helper;
using Four1Property.Models;
using Four1Property.Views.Customer;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using Xamarin.Forms;
using System.Linq;

namespace Four1Property.ViewModels
{
    public class ComapreVM
    {
        public ObservableCollection<Property> GetComapre()
        {
            string userid = App.Token;
            if(!string.IsNullOrEmpty(userid))
            {
                userid = userid.Replace("\"", "");
                var uri = string.Format(Constantce.URL + "/api/properties/GetCompare/?user={0}", userid);
                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string Data = reader.ReadToEnd();
                ObservableCollection<Property> property = JsonConvert.DeserializeObject<ObservableCollection<Property>>(Data);
                if (property != null && property.Count > 0)
                {
                    return property;
                    /*  Property property1 = property.FirstOrDefault();
                        Property property2 = property.LastOrDefault();
                        if (property1 != null && property2 != null && property1.SID != property2.SID) 
                        { 
                            await Navigation.PushModalAsync(new Compare(property1, property2));
                        }
                    */
                }
                else
                {
                    if (Settings.Language == "ar")
                    {
                        App.Current.MainPage.DisplayAlert("تنبيه", "يجب عليك اضافة عقارين او اكثر", "موافق");
                        return new ObservableCollection<Property>();
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Alert", "you have to select tow or more properties", "OK");
                        return new ObservableCollection<Property>();
                    }
                }
            }
            else
            {
                Application.Current.MainPage = new LoginPage();
                Plugin.Toast.CrossToastPopUp.Current.ShowToastError(TranslateExtension.Translate("MustLogin"), Plugin.Toast.Abstractions.ToastLength.Long);
                return new ObservableCollection<Property>();
            }
        }
    }
}
