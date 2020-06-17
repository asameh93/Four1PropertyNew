using Four1Property.Models;
using Four1Property.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Four1Property.Helper;
using Acr.UserDialogs;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Four1Property.Views.Customer;

namespace Four1Property.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agents : ContentPage
    {

        public double lon;
        public double lat;
        ObservableCollection<Agent> agents = new ObservableCollection<Agent>();

        public string uri;
        public Agents()
        {
            InitializeComponent();
            //_agent = agent;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "preventLandScape");
            if (Settings.Language == "ar")
            {
                this.FlowDirection = FlowDirection.RightToLeft;
                this.Title = "عملاء";
                if (!(string.IsNullOrEmpty(App.Token)) && App.Token != "Guest")
                {
                    ToolbarItem Profile = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "ملفي" };
                    ToolbarItem whsilist = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "المفضلة" };
                    ToolbarItem Compare = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "المقارنات" };
                    ToolbarItem Agents = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "العملاء" };
                    ToolbarItem About = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "عنا" };
                    ToolbarItem Logout = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "تسجيل الخروج" };
                    Profile.Clicked += Profile_Clicked;
                    whsilist.Clicked += Wishlist_Clicked;
                    Logout.Clicked += LogOut_Clicked;
                    Compare.Clicked += Compare_Clicked;
                    About.Clicked += About_Clicked;
                    Agents.Clicked += Agents_Clicked;
                    this.ToolbarItems.Add(Profile);
                    this.ToolbarItems.Add(whsilist);
                    this.ToolbarItems.Add(Compare);
                    this.ToolbarItems.Add(Agents);
                    this.ToolbarItems.Add(About);
                    this.ToolbarItems.Add(Logout);
                }
                else
                {
                    ToolbarItem LoginORregister = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "تسجيل الدخول" };
                    ToolbarItem Agents = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "العملاء" };
                    ToolbarItem About = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "عنا" };
                    LoginORregister.Clicked += LoginorRegister_Clicked;
                    About.Clicked += About_Clicked;
                    Agents.Clicked += Agents_Clicked;
                    this.ToolbarItems.Add(Agents);
                    this.ToolbarItems.Add(About);
                    this.ToolbarItems.Add(LoginORregister);


                }

            }
            else
            {
                if (!(string.IsNullOrEmpty(App.Token)) && App.Token != "Guest")
                {
                    ToolbarItem Profile = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "Profile" };
                    ToolbarItem whsilist = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "Wishlist" };
                    ToolbarItem Compare = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "Compare" };
                    ToolbarItem About = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "About" };
                    ToolbarItem Agents = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "Agents" };
                    ToolbarItem Logout = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "Logout" };
                    Profile.Clicked += Profile_Clicked;
                    whsilist.Clicked += Wishlist_Clicked;
                    Logout.Clicked += LogOut_Clicked;
                    About.Clicked += About_Clicked;
                    Agents.Clicked += Agents_Clicked;
                    Compare.Clicked += Compare_Clicked;
                    this.ToolbarItems.Add(Profile);
                    this.ToolbarItems.Add(whsilist);
                    this.ToolbarItems.Add(Compare);
                    this.ToolbarItems.Add(Agents);
                    this.ToolbarItems.Add(About);
                    this.ToolbarItems.Add(Logout);
                }
                else
                {
                    ToolbarItem About = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "About" };
                    ToolbarItem Agents = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "Agents" };
                    ToolbarItem LoginORregister = new ToolbarItem { Order = ToolbarItemOrder.Secondary, Text = "Login" };
                    LoginORregister.Clicked += LoginorRegister_Clicked;
                    About.Clicked += About_Clicked;
                    Agents.Clicked += Agents_Clicked;
                    this.ToolbarItems.Add(Agents);
                    this.ToolbarItems.Add(About);
                    this.ToolbarItems.Add(LoginORregister);

                }

                this.FlowDirection = FlowDirection.LeftToRight;
                this.Title = "Agents";

            }
            agents = GetAgents();
            foreach (var e in agents)
            {
                Agent agent1 = new Agent();
                if (Settings.Language == "ar")
                {
                    agent1.DirictionText = "الذهاب للموقع";
                    agent1.WebText = "الاتصال بالعميل";
                }
                else
                {
                    agent1.DirictionText = "Get Dirictions";
                    agent1.WebText = "Call Agent";
                }

                agent1.ProfileImage = e.ProfileImage;
                agent1.FirstNameAR = e.FirstNameAR;
                agent1.FirstName = e.FirstName;
                agent1.Address = e.Address;
                agent1.AddressAR = e.AddressAR;
                agent1.LastName = e.LastName;
                agent1.LastNameAR = e.LastNameAR;
                agent1.Longitude = e.Longitude;
                agent1.Latitude = e.Latitude;
                var MainGrid = new Grid
                {
                    ColumnDefinitions =
        {
          new ColumnDefinition { Width = new GridLength(150, GridUnitType.Absolute) },
          new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
        },
                    BackgroundColor = Color.White,
                    HeightRequest = 150,
                    RowSpacing = 0,
                    ColumnSpacing = 0,
                };
                var image = new Image
                {
                    Aspect = Aspect.Fill,
                };
                if (agent1.ProfileImage == "Null" || agent1.ProfileImage == string.Empty || agent1.ProfileImage == "(null)")
                {
                    image.Source = "profile2.png";
                }
                else
                {

                    image.Source = agent1.ProfileImage;
                }

                var subgrid = new Grid
                {
                    RowDefinitions =
        {
          new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },
          new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },
          new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
        },
                };
                var nameLable = new Label
                {
                    Text = agent1.FirstName + " " + agent1.LastName,
                    TextColor = Color.FromHex("#FF071D66"),
                    FontSize = 10,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                };

                var AddressLable = new Label
                {
                    Text = agent1.Address.ToString(),
                    TextColor = Color.FromHex("#FF071D66"),
                    FontSize = 10,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                };


                if (Settings.Language == "ar")
                {
                    nameLable.Text = agent1.FirstNameAR.ToString() + " " + agent1.LastNameAR.ToString();
                    AddressLable.Text = agent1.AddressAR.ToString();
                }


                var buttongrid = new Grid
                {
                    ColumnDefinitions =
        {
          new ColumnDefinition { Width = new GridLength(5, GridUnitType.Absolute) },
          new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) },
          new ColumnDefinition { Width = new GridLength(5, GridUnitType.Absolute) },
          new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) },
          new ColumnDefinition { Width = new GridLength(5, GridUnitType.Absolute) },
        },
                    RowDefinitions =
                    {
                        new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition{ Height = new GridLength(5, GridUnitType.Absolute) },
                    },
                };
                var dirictionbtn = new Button
                {
                    Text = agent1.DirictionText,
                    BackgroundColor = Color.FromHex("#FF071D66"),
                    TextColor = Color.White,
                    FontSize = 10,
                    CornerRadius = 8
                };
                var webbtn = new Button
                {
                    Text = agent1.WebText,
                    BackgroundColor = Color.FromHex("#FF071D66"),
                    TextColor = Color.White,
                    FontSize = 10,
                    CornerRadius = 8
                };
                dirictionbtn.Clicked += async (sender, args) =>
                {
                    lat = agent1.Latitude;
                    lon = agent1.Longitude;
#if __ANDROID__
                    var GetDirectionUri = Android.Net.Uri.Parse("google.navigation:q=" + lat + "," + lon);
                    var GetDirectionIntent = new Android.Content.Intent(Android.Content.Intent.ActionView, GetDirectionUri);
                    Forms.Context.StartActivity(GetDirectionIntent);
#endif
#if __IOS__
            await Launcher.OpenAsync($"comgooglemaps://?q={lat},{lon}()");
#endif
                };
                webbtn.Clicked += async (sender, args) =>
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
                };
                buttongrid.Children.Add(dirictionbtn, 1, 0);
                buttongrid.Children.Add(webbtn, 3, 0);

                subgrid.Children.Add(nameLable, 0, 0);
                subgrid.Children.Add(AddressLable, 0, 1);
                subgrid.Children.Add(buttongrid, 0, 2);

                MainGrid.Children.Add(image, 0, 0);
                MainGrid.Children.Add(subgrid, 1, 0);
                ListLayout.Children.Add(MainGrid);
                agents.Add(agent1);

            }
        }

        //need fixing to get the agent web not a defualt web
        public void VistWeb(object sender, EventArgs e)
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

        private async void GetDirection(object sender, EventArgs e)
        {
            lat = 37.759748;
            lon = -122.427135;
#if __ANDROID__
            var GetDirectionUri = Android.Net.Uri.Parse("google.navigation:q=" + lat + "," + lon);
            var GetDirectionIntent = new Android.Content.Intent(Android.Content.Intent.ActionView, GetDirectionUri);
            Forms.Context.StartActivity(GetDirectionIntent);
#endif
#if __IOS__
            await Launcher.OpenAsync($"comgooglemaps://?q={lat},{lon}()");
#endif
        }
        private async void Menu_Activated(object sender, EventArgs e)
        {

            await PopupNavigation.Instance.PushAsync(new MenuPop());
        }
        private async void LoginorRegister_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["Token"] = "Null";
            Application.Current.Properties["UEmail"] = "Null";
            var existingPages = Navigation.NavigationStack.ToList();
            await Navigation.PushModalAsync(new LoginPage());
            foreach (var page in existingPages)
            {
                Navigation.RemovePage(page);
            }
        }

        private async void Profile_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading();
            await Task.Delay(500);
            string userid = Application.Current.Properties["Token"].ToString();
            userid = userid.Replace("\"", "");
            var uri = string.Format(Constantce.URL + "/api/properties/GetProfile/?user={0}", userid);
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string Data = reader.ReadToEnd();
                ObservableCollection<Property> property = JsonConvert.DeserializeObject<ObservableCollection<Property>>(Data);
                await Navigation.PushModalAsync(new UserProfile(property));
            }
            UserDialogs.Instance.HideLoading();
        }

        private async void Wishlist_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading();
            await Task.Delay(500);
            string userid = Application.Current.Properties["Token"].ToString();
            userid = userid.Replace("\"", "");
            var uri = string.Format(Constantce.URL + "/api/properties/GetWishList/?user={0}", userid);
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string Data = reader.ReadToEnd();
                ObservableCollection<Property> property = JsonConvert.DeserializeObject<ObservableCollection<Property>>(Data);
                await Navigation.PushModalAsync(new Wishlist(property));
            }
            UserDialogs.Instance.HideLoading();
        }

        private async void Agents_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushModalAsync(new Agents());
            }
            catch
            {
                await DisplayAlert("Error", "Check App permissions. ", "Ok");
                return;
            }
        }

        private void About_Clicked(object sender, EventArgs e)
        {

        }
        private async void Compare_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading();
            await Task.Delay(500);
            string userid = Application.Current.Properties["Token"].ToString();
            userid = userid.Replace("\"", "");
            var uri = string.Format(Constantce.URL + "/api/properties/GetCompare/?user={0}", userid);
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string Data = reader.ReadToEnd();
                ObservableCollection<Property> property = JsonConvert.DeserializeObject<ObservableCollection<Property>>(Data);
                Property property1 = property.FirstOrDefault();
                Property property2 = property.LastOrDefault();
                if (property1 != null && property2 != null && property1.SID != property2.SID) { await Navigation.PushModalAsync(new Compare(property1, property2)); }
                else
                {
                    if (Settings.Language == "ar")
                    {
                        DisplayAlert("تنبيه", "يجب عليك اضافة عقارين او اكثر", "موافق");

                    }
                    else
                    {
                        DisplayAlert("Alert", "you have to select tow or more properties", "OK");
                    }
                }
            }
            UserDialogs.Instance.HideLoading();
        }
        ObservableCollection<Agent> GetAgents()
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
        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["Token"] = "Null";
            Application.Current.Properties["UEmail"] = "Null";
            Application.Current.Properties["WishP"] = "Null";
            Application.Current.Properties["ComP"] = "Null";
            var existingPages = Navigation.NavigationStack.ToList();
            await Navigation.PushModalAsync(new LoginPage());
            foreach (var page in existingPages)
            {
                Navigation.RemovePage(page);
            }
        }
    }
}

