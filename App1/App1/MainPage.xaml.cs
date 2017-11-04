using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.MenuItems;
using App1.Views;
using Xamarin.Forms;

namespace App1
{

    public partial class MainPage : MasterDetailPage
    {

        public List<MasterPageItem> MenuList { get; set; }

        public MainPage()
        {

            InitializeComponent();

            MenuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Item 1", Icon = "itemIcon1.png", TargetType = typeof(Page1) };
            var page2 = new MasterPageItem() { Title = "Item 2", Icon = "itemIcon2.png", TargetType = typeof(Page2) };
            var page3 = new MasterPageItem() { Title = "Item 3", Icon = "itemIcon3.png", TargetType = typeof(Page3) };

            // Adding menu items to menuList
            MenuList.Add(page1);
            MenuList.Add(page2);
            MenuList.Add(page3);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = MenuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Page1)));
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}