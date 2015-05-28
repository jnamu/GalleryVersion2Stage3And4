using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Gallery4Phone.Resources;
using Gallery4Phone.ServiceReference1;

namespace Gallery4Phone
{
    public partial class pgMain : PhoneApplicationPage
    {
        // Constructor
        public pgMain()
        {
            InitializeComponent();
            SvcClient.GetArtistNamesCompleted += SvcClient_GetArtistNamesCompleted;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void SvcClient_GetArtistNamesCompleted(object sender, GetArtistNamesCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                    lstArtists.ItemsSource = e.Result;
                else
                    txbMessage.Text = e.Error.Message;
            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.Message;
            }
            //throw new NotImplementedException();
        }

        public static readonly Service1Client SvcClient = new Service1Client();

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            SvcClient.GetArtistNamesAsync();
        }

        public void EditArtist()
        {
            if (lstArtists.SelectedItem != null)
                NavigationService.Navigate(new Uri("/pgArtist.xaml?artist=" + lstArtists.SelectedItem, UriKind.Relative));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditArtist();
        }

        private void lstArtists_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EditArtist();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/pgArtist.xaml", UriKind.Relative));
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}