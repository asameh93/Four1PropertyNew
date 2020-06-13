using Acr.UserDialogs;
using Four1Property.Helpers;
using Four1Property.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Four1Property.ViewModels
{
    public class SearchByIdVM : BaseViewModel
    {
        public Command SearchByIDCommand { get; set; }
        public string PropertyId { get; set; }

        public SearchByIdVM()
        {
            SearchByIDCommand = new Command(Search);
        }

        private async void Search(object obj)
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    if (!string.IsNullOrEmpty(PropertyId))
                    {
                        if (PropertyId != null && PropertyId != "0" && !PropertyId.StartsWith("0") && PropertyId!= " " && !PropertyId.StartsWith(" "))
                        {
                            var ID = PropertyId;
                            var value = false;
                            UserDialogs.Instance.ShowLoading();
                            var uri = "";
                            if (ID.Contains("RA") || ID.Contains("ra") || ID.Contains("Ra")) { uri = string.Format(Constantce.URL + "/api/properties/SearchAppartment?ID={0}", ID); value = true; }
                            else if (ID.Contains("RB") || ID.Contains("rb") || ID.Contains("Rb")) { uri = string.Format(Constantce.URL + "/api/properties/SearchBuilding?ID={0}", ID); value = true; }
                            else if (ID.Contains("RF") || ID.Contains("rf") || ID.Contains("Rf")) { uri = string.Format(Constantce.URL + "/api/properties/SearchFlat?ID={0}", ID); value = true; }
                            else if (ID.Contains("RH") || ID.Contains("rh") || ID.Contains("Rh")) { uri = string.Format(Constantce.URL + "/api/properties/SearchHouse?ID={0}", ID); value = true; }
                            else if (ID.Contains("IB") || ID.Contains("ib") || ID.Contains("Ib")) { uri = string.Format(Constantce.URL + "/api/properties/Searchindbuilding?ID={0}", ID); value = true; }
                            else if (ID.Contains("IH") || ID.Contains("ih") || ID.Contains("Ih")) { uri = string.Format(Constantce.URL + "/api/properties/Searchindhangar?ID={0}", ID); value = true; }
                            else if (ID.Contains("LA") || ID.Contains("la") || ID.Contains("La")) { uri = string.Format(Constantce.URL + "/api/properties/Searchlandagre?ID={0}", ID); value = true; }
                            else if (ID.Contains("LC") || ID.Contains("lc") || ID.Contains("Lc")) { uri = string.Format(Constantce.URL + "/api/properties/Searchlandcom?ID={0}", ID); value = true; }
                            else if (ID.Contains("LI") || ID.Contains("li") || ID.Contains("Li")) { uri = string.Format(Constantce.URL + "/api/properties/Searchlandind?ID={0}", ID); value = true; }
                            else if (ID.Contains("LR") || ID.Contains("lr") || ID.Contains("Lr")) { uri = string.Format(Constantce.URL + "/api/properties/Searchlandres?ID={0}", ID); value = true; }
                            else if (ID.Contains("CR") || ID.Contains("cr") || ID.Contains("Cr")) { uri = string.Format(Constantce.URL + "/api/properties/Searchcomshowroom?ID={0}", ID); value = true; }
                            else if (ID.Contains("CO") || ID.Contains("co") || ID.Contains("Co")) { uri = string.Format(Constantce.URL + "/api/properties/Searchcomoffice?ID={0}", ID); value = true; }
                            else if (ID.Contains("CS") || ID.Contains("cs") || ID.Contains("Cs")) { uri = string.Format(Constantce.URL + "/api/properties/Searchcomshop?ID={0}", ID); value = true; }
                            else if (ID.Contains("CB") || ID.Contains("cb") || ID.Contains("Cb")) { uri = string.Format(Constantce.URL + "/api/properties/Searchcombuilding?ID={0}", ID); value = true; }
                            /*if (value == true)
                            {
                                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                                {
                                    StreamReader reader = new StreamReader(response.GetResponseStream());
                                    string Data = reader.ReadToEnd();
                                    ObservableCollection<PropertyModel> property = JsonConvert.DeserializeObject<ObservableCollection<PropertyModel>>(Data);
                                    if (property.Count != 0)
                                    {
                                        PropertyModel PropertyID = property.FirstOrDefault();
                                        PropertyID.AllPhotos = PropertyID.Photos;
                                        PropertyID.AllPhotos.Add(PropertyID.PhotoQ);
                                        if (PropertyID.PhotoQ2 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ2); }
                                        if (PropertyID.PhotoQ3 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ3); }
                                        if (PropertyID.PhotoQ4 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ4); }
                                        if (PropertyID.PhotoQ5 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ5); }
                                        if (PropertyID.PhotoQ6 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ6); }
                                        if (PropertyID.PhotoQ7 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ7); }
                                        if (PropertyID.PhotoQ8 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ8); }
                                        if (PropertyID.PhotoQ9 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ9); }
                                        if (PropertyID.PhotoQ10 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ10); }
                                        if (PropertyID.PhotoQ11 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ11); }
                                        if (PropertyID.PhotoQ12 != null) { PropertyID.AllPhotos.Add(PropertyID.PhotoQ12); }
                                        await Navigation.PushAsync(new PropertyProfile(PropertyID));
                                        await PopupNavigation.Instance.PopAsync();
                                    }
                                    else
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        if (Application.Current.Properties["Language"].ToString() == "Arabic")
                                        {
                                            IDEntry.Text = "";
                                            IDEntry.Placeholder = "يرجى ادخال رقم العقار الصحيح";
                                            IDEntry.PlaceholderColor = Color.Red;
                                        }
                                        else
                                        {
                                            IDEntry.Text = "";
                                            IDEntry.Placeholder = "Please Enter a valid Property ID";
                                            IDEntry.PlaceholderColor = Color.Red;
                                        }
                                    }
                                }
                                UserDialogs.Instance.HideLoading();
                            }
                            else
                            {
                                UserDialogs.Instance.HideLoading();
                                if (Application.Current.Properties["Language"].ToString() == "Arabic")
                                {
                                    IDEntry.Text = "";
                                    IDEntry.Placeholder = "يرجى ادخال رقم العقار الصحيح";
                                    IDEntry.PlaceholderColor = Color.Red;
                                }
                                else
                                {
                                    IDEntry.Text = "";
                                    IDEntry.Placeholder = "Please Enter a valid Property ID";
                                    IDEntry.PlaceholderColor = Color.Red;
                                }
                            }*/
                        }
                    }
                    else
                    {
                        Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helpers.TranslateExtension.Translate("EnterIDNumber"), Plugin.Toast.Abstractions.ToastLength.Long);
                    }
                }
                else
                {
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastError(Helpers.TranslateExtension.Translate("Msg_ConnectionError"), Plugin.Toast.Abstractions.ToastLength.Long);
                }
            }
            catch (global::System.Exception)
            {
            }
        }
    }
}
