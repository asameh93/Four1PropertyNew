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
using SlideOverKit;

namespace Four1Property.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agents : MenuContainerPage
    {

        public double lon;
        public double lat;
        ObservableCollection<Agent> agents ;

        public string uri;
        public Agents()
        {
            InitializeComponent();
            this.SlideMenu = new SlideMenu();
            BindingContext = new AgentsVM();
            if (Settings.Language == "ar")
            {
                this.FlowDirection = FlowDirection.RightToLeft;
                this.Title = "عملاء";
            }
            else
            {
                this.FlowDirection = FlowDirection.LeftToRight;
                this.Title = "Agents";
            }
        }

        void OpenSlide(object sender, EventArgs e)
        {
            this.ShowMenu();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "preventLandScape");
            
            agents = new ObservableCollection<Agent>();
            agents = ((AgentsVM)BindingContext).GetAgents();
          
            if(agents != null && agents.Count >0)
            {
                foreach (var item in agents)
                {
                    if (string.IsNullOrEmpty(item.ProfileImage))
                        item.ProfileImage = "profile2";
                }
            }
            agentsListView.ItemsSource = agents;
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

        private async void Compare_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}

