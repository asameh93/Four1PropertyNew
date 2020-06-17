using Four1Property.Helper;
using Four1Property.Models;
using Four1Property.ViewModels;
using Four1Property.Views.Customer;
using SlideOverKit;
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
    public partial class SlideMenu : SlideMenuView
    {
        public List<MenuItemModel> MenuListItems { get; set; }

        public SlideMenu()
        {
            try
            {
                InitializeComponent();
                this.IsFullScreen = true;
                this.WidthRequest = 230;
                this.BackgroundViewColor = Color.Transparent;

                if (Settings.Language.Equals("en"))
                {
                    MenuList.ItemsSource = SetMenu();
                    this.MenuOrientations = MenuOrientation.LeftToRight;
                }
                else
                {
                    MenuList.ItemsSource = SetArabicMenu();
                    MenuList.FlowDirection = FlowDirection.RightToLeft;
                    this.MenuOrientations = MenuOrientation.RightToLeft;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        public List<MenuItemModel> SetMenu()
        {
            MenuListItems = new List<MenuItemModel>()
            {
                new MenuItemModel(){icon="slidemenuaccount.png",title="Profile"},
                new MenuItemModel(){icon="vr.png",title="WishList"},
                new MenuItemModel(){icon="slidemenucontact.png",title="Contact Us"},
                new MenuItemModel(){icon="about.png",title="About Us"},
                new MenuItemModel(){icon="terms_icon.png",title="Terms&Condition"},
                new MenuItemModel(){icon="setting",title="Setting"},
                new MenuItemModel(){icon="slidemenuexit.png",title="Log Out"},
            };
            return MenuListItems;
        }
        public List<MenuItemModel> SetArabicMenu()
        {
            MenuListItems = new List<MenuItemModel>()
            {
                new MenuItemModel(){icon="slidemenuaccount.png",title="الملف الشخصى"},
                 new MenuItemModel(){icon="vr.png",title="المفضلة"},
                new MenuItemModel(){icon="slidemenucontact.png",title="تواصل معنا"},
                new MenuItemModel(){icon="about.png",title="من نحن"},
                new MenuItemModel(){icon="terms_icon.png",title="الشروط والاحكام"},
                new MenuItemModel(){icon="setting",title="الاعدادات"},
                new MenuItemModel(){icon="slidemenuexit.png",title="تسجيل الخروج"},
            };
            return MenuListItems;
        }
        private async void MenuList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var selectedItem = (MenuItemModel)e.Item;
                if (selectedItem.title.Equals("Profile") || selectedItem.title.Equals("الملف الشخصى"))
                {
                    this.HideWithoutAnimations();
                    await Navigation.PushModalAsync(new UserProfile(new System.Collections.ObjectModel.ObservableCollection<Property>()));
                }
                else if (selectedItem.title.Equals("Home") || selectedItem.title.Equals("الصفحة الرئيسية"))
                {
                    this.HideWithoutAnimations();
                    Application.Current.MainPage = new MainPage();
                }
                else if (selectedItem.title.Equals("Setting") || selectedItem.title.Equals("الاعدادات"))
                {
                    try
                    {
                        this.HideWithoutAnimations();
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                    }
                }
                else if (selectedItem.title.Equals("Contact Us") || selectedItem.title.Equals("تواصل معنا"))
                {
                    this.HideWithoutAnimations();
                }
                else if (selectedItem.title.Equals("About Us") || selectedItem.title.Equals("من نحن"))
                {
                    this.HideWithoutAnimations();
                }
                else if (selectedItem.title.Equals("Terms&Condition") || selectedItem.title.Equals("الشروط والاحكام"))
                {
                    this.HideWithoutAnimations();
                }
                else if (selectedItem.title.Equals("Log Out") || selectedItem.title.Equals("تسجيل الخروج"))
                {
                    HideWithoutAnimations();
                    App.Email = "";
                    App.Token = "";
                    App.Current.MainPage = new LoginPage();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}