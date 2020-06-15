using Four1Property.Helpers;
using Four1Property.Models;
using Four1Property.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Four1Property.ViewModels
{
    public class HomeVM : BaseViewModel
    {
        public List<CountryModel> Countries { get; set; }
        public List<CityModel> Cities { get; set; }

        public Command GetCurrentLocation { get; set; }
        public Command GetFromMap { get; set; }

        public HomeVM()
        {
            try
            {
                GetCurrentLocation = new Command(getCurrentLocation);
                GetFromMap = new Command(getFromMap);
            }
            catch (Exception)
            {
            }
        }

        private void getFromMap()
        {
            try
            {
                App.Current.MainPage.Navigation.PushModalAsync(new SetLocation());
            }
            catch (Exception)
            {
            }
        }

        private async void getCurrentLocation()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if(status == PermissionStatus.Granted)
                    {
                        var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                        var location = await Geolocation.GetLocationAsync(request);
                        if (location != null)
                        {
                            Constantce.Lat = location.Latitude;
                            Constantce.lon = location.Longitude;
                            Plugin.Toast.CrossToastPopUp.Current.ShowToastSuccess(Helpers.TranslateExtension.Translate("GetLocation"), Plugin.Toast.Abstractions.ToastLength.Long);
                        }
                        else
                        {
                            Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helpers.TranslateExtension.Translate("NoLocation"), Plugin.Toast.Abstractions.ToastLength.Long);
                        }
                    }
                }
                else
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                    var location = await Geolocation.GetLocationAsync(request);
                    if (location != null)
                    {
                        Constantce.Lat = location.Latitude;
                        Constantce.lon = location.Longitude;
                        Plugin.Toast.CrossToastPopUp.Current.ShowToastSuccess(Helpers.TranslateExtension.Translate("GetLocation"), Plugin.Toast.Abstractions.ToastLength.Long);
                    }
                    else
                    {
                        Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helpers.TranslateExtension.Translate("NoLocation"), Plugin.Toast.Abstractions.ToastLength.Long);
                    }
                }

                try
                {

                    var stream1 = await FileSystem.OpenAppPackageFileAsync("Countries");
                    var reader1 = new StreamReader(stream1);
                    var fileContents1 = await reader1.ReadToEndAsync();
                    Countries = JsonConvert.DeserializeObject<List<CountryModel>>(fileContents1);
                    Cities = Countries[0].Cities;
                }
                catch (Exception ex)
                {
                    string er = ex.Message;
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }        
        }
    }
}
