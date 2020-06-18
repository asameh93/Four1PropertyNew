using Acr.UserDialogs;
using Four1Property.Helper;
using Four1Property.Models;
using Four1Property.Views.Customer;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace Four1Property.ViewModels
{
    public class WishListViewModel
    {
        public ObservableCollection<Property> GetWishList()
        {
            UserDialogs.Instance.ShowLoading();
            string userid = App.Token;
            if(!string.IsNullOrEmpty(userid))
            {
                userid = userid.Replace("\"", "");
                var uri = string.Format(Constantce.URL + "/api/properties/GetWishList/?user={0}", userid);
                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                UserDialogs.Instance.HideLoading();
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string Data = reader.ReadToEnd();
                    ObservableCollection<Property> property = JsonConvert.DeserializeObject<ObservableCollection<Property>>(Data);
                    return property;
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
