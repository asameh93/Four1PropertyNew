using Acr.UserDialogs;
using Four1Property.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace Four1Property.Services
{
    public class ApiService
    {
        public static AppSetting AppLanguage { get; set; }
        private const string ApiAddress = "https://property1111.com/api";
        public static string ImageUrl = "https://property1111.com/";
        public static async Task<T> GetOneWithPost<T, T1>(T1 data, string control, string action)
        {
            DetectLanguage();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(data);
                var dataConverted = new StringContent(json, Encoding.UTF8, "application/json");
                var url = $"{ApiAddress}/{control}/{action}";
                try
                {
                    if (AppLanguage.language.Equals("ar"))
                    {
                        UserDialogs.Instance.ShowLoading("أنتظر من فضلك ");
                        client.DefaultRequestHeaders.Add("Language", "arabic"); 
                    }
                    else
                    {
                        UserDialogs.Instance.ShowLoading("Please Wait ... ");
                        client.DefaultRequestHeaders.Add("Language", "English");
                    }
                        
                    var response = await client.PostAsync(url, dataConverted);
                    UserDialogs.Instance.HideLoading();
                    var content = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<T>(content);
                    return obj;
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    UserDialogs.Instance.HideLoading();
                    return default(T);
                }
            }
            else
            {
                if (AppLanguage.language.Equals("ar"))
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError("تحقق من وجود إنترنت", Plugin.Toast.Abstractions.ToastLength.Long);
                else
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Check Internet Connection", Plugin.Toast.Abstractions.ToastLength.Long);
                return default(T);
            }
        }
        public static async Task<T> GetOneWithoutData<T>(string control, string action)
        {
            DetectLanguage();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                var client = new HttpClient();
                var url = $"{ApiAddress}/{control}/{action}";
                try
                {
                    //if (AppLanguage.language.Equals("ar"))
                    //{
                    //    UserDialogs.Instance.ShowLoading("أنتظر من فضلك ");
                    //    client.DefaultRequestHeaders.Add("Language", "arabic");
                    //}
                    //else
                    //{
                    //    UserDialogs.Instance.ShowLoading("Please Wait ... ");
                    //    client.DefaultRequestHeaders.Add("Language", "English");
                    //}
                    var request = await client.GetAsync(url);
                    UserDialogs.Instance.HideLoading();
                    var content = await request.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<T>(content);
                    return obj;
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    UserDialogs.Instance.HideLoading();
                    return default(T);
                }
            }
            else
            {
                if (AppLanguage.language.Equals("ar"))
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError("تحقق من وجود إنترنت", Plugin.Toast.Abstractions.ToastLength.Long);
                else
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Check Internet Connection", Plugin.Toast.Abstractions.ToastLength.Long);
                return default(T);
            }
        }

        public static async Task<T> GetDataWithoutLoading<T>(string control, string action)
        {
            DetectLanguage();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                var client = new HttpClient();
                var url = $"{ApiAddress}/{control}/{action}";
                try
                {
                    if (AppLanguage.language.Equals("ar"))
                    {
                       client.DefaultRequestHeaders.Add("Language", "arabic");
                    }
                    else
                    {
                        client.DefaultRequestHeaders.Add("Language", "English");
                    }
                    var request = await client.GetAsync(url);
                    var content = await request.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<T>(content);
                    return obj;
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    return default(T);
                }
            }
            else
            {
                if (AppLanguage.language.Equals("ar"))
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError("تحقق من وجود إنترنت", Plugin.Toast.Abstractions.ToastLength.Long);
                else
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Check Internet Connection", Plugin.Toast.Abstractions.ToastLength.Long);
                return default(T);
            }
        }
        public static async Task<T> GetOneWithOutLoading<T, T1>(T1 data, string control, string action)
        {
            DetectLanguage();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(data);
                var dataConverted = new StringContent(json, Encoding.UTF8, "application/json");
                if (AppLanguage.language.Equals("ar"))
                {
                    client.DefaultRequestHeaders.Add("Language", "arabic");
                }
                else
                {
                    client.DefaultRequestHeaders.Add("Language", "English");
                }
                var url = $"{ApiAddress}/{control}/{action}";
                try
                {
                    var response = await client.PostAsync(url, dataConverted);
                    var content = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<T>(content);
                    return obj;
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    UserDialogs.Instance.HideLoading();
                    return default(T);
                }
            }
            else
            {
                if (AppLanguage.language.Equals("ar"))
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError("تحقق من وجود إنترنت", Plugin.Toast.Abstractions.ToastLength.Long);
                else
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Check Internet Connection", Plugin.Toast.Abstractions.ToastLength.Long);
                return default(T);
            }
        }
        private static void DetectLanguage()
        {
            AppLanguage = SqliteService.GetOneObject<AppSetting>();
        }
    }
}
