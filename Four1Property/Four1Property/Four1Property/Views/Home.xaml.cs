using Four1Property.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Four1Property.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            NavigationPage.BarBackgroundColorProperty.Equals(Color.Transparent);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "preventLandScape");
        }
        //Rent OR Sale Start
        async void OnSaleClicked(object sender, EventArgs e)
        {
         
        }

        async void OnRentClicked(object sender, EventArgs e)
        {
         
        }
        //Rent OR Sale End

        // Start Main Cat
        private async void CurrentLocation_Clicked(object sender, EventArgs e)
        {
        }
        async void CountryPicker_Clicked(object sender, EventArgs e)
        {

        }
        async void AreaPicker_Clicked(object sender, EventArgs e)
        {
            
        }
        async void CityPicker_Clicked(object sender, EventArgs e)
        {
            
        }
        private void CommercialMain_Clicked(object sender, EventArgs e)
        {
            

        }
        private void IndustrialMain_Clicked(object sender, EventArgs e)
        {
          

        }
        private void ResidentialMain_Clicked(object sender, EventArgs e)
        {
            

        }
        private void LandMain_Clicked(object sender, EventArgs e)
        {
          

        }
        //Main Category
        //Back Arrow Start
        private void backmain_Tapped(object sender, EventArgs e)
        {
        }
        //Back Arrow End
        //residential buttons code
        private void HouseButton_Clicked(object sender, EventArgs e)
        {
           
        }

        private void FlatButton_Clicked(object sender, EventArgs e)
        {
           
        }

        private void ApartmentButton_Clicked(object sender, EventArgs e)
        {
          
        }

        private void BuildingButton_Clicked(object sender, EventArgs e)
        {
           
        }

        private void FurnishedButton_Clicked(object sender, EventArgs e)
        {
        }

        private void UnFernishedButton_Clicked(object sender, EventArgs e)
        {
          
        }
        //end of buttons residential code



        //start of buttons commercial code
        private void ShowRoomButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void OfficeButton_Clicked(object sender, EventArgs e)
        {
         
        }

        private void ShopsButton_Clicked(object sender, EventArgs e)
        {
        }

        private void BuildingComButton_Clicked(object sender, EventArgs e)
        {
           
        }
        // end of commercial buttom code



        // start of Land buttom code
        private void CommercialButton_Clicked(object sender, EventArgs e)
        {
           
        }

        private void IndustrialButton_Clicked(object sender, EventArgs e)
        {
           
        }

        private void ResidentialButton_Clicked(object sender, EventArgs e)
        {
          
        }

        private void AgrecultureComButton_Clicked(object sender, EventArgs e)
        {
            
        }
        //end of Land buttons code


        //start of industrial buttons code
        private void HangerButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void BuildingIndButton_Clicked(object sender, EventArgs e)
        {
            
        }
        //end of industrial buttons code


        // Apply Button
        async private void ApplyFilter_Clicked(object sender, EventArgs e)
        {
          
        }
        //End Apply Button


        // Nav Bar Start
        void OnHomeButtonClicked(object sender, EventArgs e)
        {

       
        }

        async void OnSearchButtonClicked(object sender, EventArgs e)
        {
          
        }

        async void OnFavoriteButtonClicked(object sender, EventArgs e)
        {
          
        }

        async void OnProfileButtonClicked(object sender, EventArgs e)
        {
        }
        //Nav Bar End

        private async void MapView_Clicked(object sender, EventArgs e)
        {

        }

        //number of beds start
        private void bed1unchecked(object sender, EventArgs e)
        {
        }
        private void bed1checked(object sender, EventArgs e)
        {
        }
        private void bed2unchecked(object sender, EventArgs e)
        {
        }
        private void bed2checked(object sender, EventArgs e)
        {
        }
        private void bed3unchecked(object sender, EventArgs e)
        {
        }
        private void bed3checked(object sender, EventArgs e)
        {
        }
        private void bed4unchecked(object sender, EventArgs e)
        {
           
        }
        private void bed4checked(object sender, EventArgs e)
        {
          
        }
        //number of beds end

        //number of baths start
        private void bath1unchecked(object sender, EventArgs e)
        {
          
        }
        private void bath1checked(object sender, EventArgs e)
        {
           
        }
        private void bath2unchecked(object sender, EventArgs e)
        {
            
        }
        private void bath2checked(object sender, EventArgs e)
        {
            
        }
        private void bath3unchecked(object sender, EventArgs e)
        {
           
        }
        private void bath3checked(object sender, EventArgs e)
        {
           
        }
        private void bath4unchecked(object sender, EventArgs e)
        {
           
        }
        private void bath4checked(object sender, EventArgs e)
        {
           
        }
        //number of baths end

        //land area raadio buttons start
        private void area1unchecked(object sender, EventArgs e)
        {
          
        }
        private void area1checked(object sender, EventArgs e)
        {
           
        }
        private void area2unchecked(object sender, EventArgs e)
        {
          
        }
        private void area2checked(object sender, EventArgs e)
        {
          
        }
        private void area3unchecked(object sender, EventArgs e)
        {
          
        }
        private void area3checked(object sender, EventArgs e)
        {
          
        }
        private void area4unchecked(object sender, EventArgs e)
        {
          
        }
        private void area4checked(object sender, EventArgs e)
        {
        
        }
        private void area5unchecked(object sender, EventArgs e)
        {
           
        }
        private void area5checked(object sender, EventArgs e)
        {
            
        }

        private async void Menu_Activated(object sender, EventArgs e)
        {

        }
        //land area radio buttons end 
        private async void LoginorRegister_Clicked(object sender, EventArgs e)
        {
           
        }

        private async void Profile_Clicked(object sender, EventArgs e)
        {
          
        }

        private async void Compare_Clicked(object sender, EventArgs e)
        {
            
        }
        private async void Wishlist_Clicked(object sender, EventArgs e)
        {
           
        }

        private async void Agents_Clicked(object sender, EventArgs e)
        {
            try
            {


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

        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["Token"] = "Null";
            Application.Current.Properties["UEmail"] = "Null";
            Application.Current.Properties["WishP"] = "Null";
            Application.Current.Properties["ComP"] = "Null";
            var existingPages = Navigation.NavigationStack.ToList();
            await Navigation.PushAsync(new LoginPage());
            foreach (var page in existingPages)
            {
                Navigation.RemovePage(page);
            }
        }
    }

}