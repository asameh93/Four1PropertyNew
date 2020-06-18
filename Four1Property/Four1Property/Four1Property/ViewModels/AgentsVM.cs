using Acr.UserDialogs;
using Four1Property.Helper;
using Four1Property.Models;
using Four1Property.Services;
using Four1Property.Views.AreaPickers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Four1Property.ViewModels
{
    public class AgentsVM : BaseViewModel
    {
        public Command GetDirectionCommand { get; set; }
        public Command CallCommand { get; set; }

        public AgentsVM()
        {
            GetDirectionCommand = new Command<Agent>(GetDirection);
            CallCommand = new Command<Agent>(Call);

        }

        private void Call(Agent obj)
        {
            try
            {
                try
                {
                    PhoneDialer.Open("0799710919");
                }
                catch (ArgumentNullException anEx)
                {
                    // Number was null or white space
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Phone Dialer is not supported on this device.
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            }
            catch (Exception)
            {
            }
        }

        private async void GetDirection(Agent obj)
        {
            try
            {
                if(obj.Latitude > 0&& obj.Longitude > 0)
                {
                    var location = new Location(obj.Latitude, obj.Longitude);
                    var options = new MapLaunchOptions { Name = obj.FullName };
                    try
                    {
                        await Map.OpenAsync(location, options);
                    }
                    catch (Exception ex)
                    {
                        // No map application available to open
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

        public ObservableCollection<Agent> GetAgents()
        {
            UserDialogs.Instance.ShowLoading();
            var uri = string.Format(Constantce.URL + "/api/properties/GetAgents");
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            UserDialogs.Instance.HideLoading();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string Data = reader.ReadToEnd();
            var agent = JsonConvert.DeserializeObject<ObservableCollection<Agent>>(Data);
            return agent;
        }

        /*
         
          UserDialogs.Instance.ShowLoading();
            var uri = string.Format(Constantce.URL + "/api/properties/GetAgents");
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            UserDialogs.Instance.HideLoading();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string Data = reader.ReadToEnd();
            var agent = JsonConvert.DeserializeObject<ObservableCollection<Agent>>(Data);
            return agent;
         
         
         */
    }
}
