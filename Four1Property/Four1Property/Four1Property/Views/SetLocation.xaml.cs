using Four1Property.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace Four1Property.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetLocation : ContentPage
    {
        public SetLocation()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if(status == PermissionStatus.Granted)
                    {
                        var request = new GeolocationRequest(GeolocationAccuracy.High);
                        var location = await Geolocation.GetLocationAsync(request);
                        if (location != null)
                        {
                            Pin pin = new Pin
                            {
                                Type = PinType.Place,
                                Position = new Position(location.Latitude, location.Longitude),
                                Label = "Drag ME",
                                IsDraggable = true,
                            };
                            pin.Icon = BitmapDescriptorFactory.FromView(new ContentView()
                            {
                                WidthRequest = 20,
                                HeightRequest = 20,
                                BackgroundColor = Color.Blue,
                                Content = new Image()
                                {
                                    Source = ImageSource.FromFile("markericon.png")
                                }
                            });
                            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(0.5)));
                            myMap.Pins.Add(pin);

                            // draw Circle
                            Circle circle = new Circle
                            {
                                Center = new Position(location.Latitude, location.Longitude),
                                Radius = new Distance(500),
                                StrokeColor = Color.FromHex("#88FF0000"),
                                StrokeWidth = 5,
                                FillColor = Color.FromHex("#88FFC0CB")
                            };
                            myMap.Circles.Add(circle);

                            Constantce.Lat = location.Latitude;
                            Constantce.lon = location.Longitude;
                        }
                    }
                }
                else
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.High);
                    var location = await Geolocation.GetLocationAsync(request);
                    if (location != null)
                    {
                        Pin pin = new Pin
                        {
                            Type = PinType.Place,
                            Position = new Position(location.Latitude, location.Longitude),
                            Label = "Drag ME",
                            IsDraggable = true,
                        };
                        pin.Icon = BitmapDescriptorFactory.FromView(new ContentView()
                        {
                            WidthRequest = 20,
                            HeightRequest = 20,
                            BackgroundColor = Color.Blue,
                            Content = new Image()
                            {
                                Source = ImageSource.FromFile("markericon.png")
                            }
                        });
                        myMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(0.5)));
                        myMap.Pins.Add(pin);

                        // draw Circle
                        Circle circle = new Circle
                        {
                            Center = new Position(location.Latitude, location.Longitude),
                            Radius = new Distance(500),
                            StrokeColor = Color.FromHex("#88FF0000"),
                            StrokeWidth = 5,
                            FillColor = Color.FromHex("#88FFC0CB")
                        };
                        myMap.Circles.Add(circle);

                        Constantce.Lat = location.Latitude;
                        Constantce.lon = location.Longitude;
                    }
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Enable Location from setting to get your location", Plugin.Toast.Abstractions.ToastLength.Short);
                Pin pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(31.9454, 35.9284),
                    Label = "Drag ME",
                    IsDraggable = true,
                };
                pin.Icon = BitmapDescriptorFactory.FromView(new ContentView()
                {
                    WidthRequest = 40,
                    HeightRequest = 40,
                    BackgroundColor = Color.Blue,
                    Content = new Image()
                    {
                        Source = ImageSource.FromFile("markericon.png")
                    }
                });
                myMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(31.9454, 35.9284), Distance.FromKilometers(0.5)));
                myMap.Pins.Add(pin);

                // draw Circle
                Circle circle = new Circle
                {
                    Center = new Position(31.9454, 35.9284),
                    Radius = new Distance(500),
                    StrokeColor = Color.FromHex("#88FF0000"),
                    StrokeWidth = 5,
                    FillColor = Color.FromHex("#88FFC0CB")
                };
                myMap.Circles.Add(circle);
            }

        }
        private void MyMap_MapClicked(object sender, MapClickedEventArgs e)
        {
            myMap.Pins.Clear();
            Pin pin1 = new Pin()
            {
                Position = new Position(e.Point.Latitude, e.Point.Longitude),
                Address = "",
                Label = "",
            };
            pin1.Icon = BitmapDescriptorFactory.FromView(new ContentView()
            {
                WidthRequest = 20,
                HeightRequest = 20,
                BackgroundColor = Color.Blue,
                Content = new Image()
                {
                    Source = ImageSource.FromFile("markericon.png")
                }
            });
            myMap.Pins.Add(pin1);

            // draw Circle
            Circle circle = new Circle
            {
                Center = new Position(pin1.Position.Latitude, pin1.Position.Longitude),
                Radius = new Distance(500),
                StrokeColor = Color.FromHex("#88FF0000"),
                StrokeWidth = 5,
                FillColor = Color.FromHex("#88FFC0CB")
            };
            myMap.Circles.Add(circle);

            Constantce.Lat = e.Point.Latitude;
            Constantce.lon = e.Point.Longitude;
        }
    }
}