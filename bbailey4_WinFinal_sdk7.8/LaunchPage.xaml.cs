using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using System.Device.Location;
using System.Diagnostics;
using System.Collections.ObjectModel;
using bbailey4_WinFinal_sdk7._8.GeocodeService;

namespace bbailey4_WinFinal_sdk7._8
{
    public partial class LaunchPage : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher;
        
        // Default IIT Tower Lat and Long
        static readonly String DEFAULT_LATITUDE = "41.83128";
        static readonly String DEFAULT_LONGITUDE = "-87.62697";

        public LaunchPage()
        {
            InitializeComponent();
            // Initialize Distance Picker
            this.distancePicker.ItemsSource = new List<String>() { "100 Feet", "250 Feet", "500 Feet", "1000 Feet", "1/4 Mile", "1/2 Mile", "1 Mile" };
            this.distancePicker.SelectedIndex = 2;
            // Initialize Date Range Picker
            this.datePicker.ItemsSource = new List<String>() { "in Last 2 Weeks", "in Last Month", "in Last 2 Months", "in Last 3 Months", "in Last 6 Months", "in Last Year" };
            this.datePicker.SelectedIndex = 1;
            //this.Loaded += new RoutedEventHandler(LaunchPage_Loaded);
            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            watcher.MovementThreshold = 10;
        }

        
        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            latitudeTB.Text = "Latitude: " + e.Position.Location.Latitude.ToString();
            longitudeTB.Text = "Longitude: " + e.Position.Location.Longitude.ToString();
        }


        private void searchLocationButton_Click(object sender, RoutedEventArgs e)
        {
            // Get GPS for Watcher
            String latitude = "";
            String longitude = "";
            if (watcher.Position.Location.IsUnknown || watcher.Permission == GeoPositionPermission.Denied || watcher.Permission == GeoPositionPermission.Unknown)
            {
                latitude = DEFAULT_LATITUDE;
                longitude = DEFAULT_LONGITUDE;
            }
            else
            {
                latitude = watcher.Position.Location.Latitude.ToString();
                longitude = watcher.Position.Location.Longitude.ToString();
            }
            watcher.Stop();
            
            // Get search date string based on selection in control
            //String searchDate = "2013-04-10T00:00:00";
            String searchDate = getSearchDate(this.datePicker.SelectedIndex);

            // Get Distance index from Control
            String distanceIndex = distancePicker.SelectedIndex.ToString();

            // Navigate to Crime List
            NavigationService.Navigate(new Uri("/MainPage.xaml?lat=" + latitude + "&long=" + longitude + "&date=" + searchDate + "&dist=" + distanceIndex, UriKind.Relative));
        }


        private String getSearchDate(int datePos)
        {
            DateTime now = DateTime.Now;
            DateTime searchDate;
            switch (datePos)
            {
                case 0:
                    searchDate = now.AddDays(-14);
                    break;
                case 1:
                    searchDate = now.AddMonths(-1);
                    break;
                case 2:
                    searchDate = now.AddMonths(-2);
                    break;
                case 3:
                    searchDate = now.AddMonths(-3);
                    break;
                case 4:
                    searchDate = now.AddMonths(-6);
                    break;
                case 5:
                    searchDate = now.AddYears(-1);
                    break;
                default:
                    searchDate = now;
                    break;
            }
            String dateString = searchDate.ToString("yyyy-MM-dd");
            return dateString + "T00:00:00";
        }

        /*
        // Load data for the ViewModel Items
        private void LaunchPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        //*/

        // When page is navigated
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            watcher.Start();
            if (watcher.Position.Location.IsUnknown || watcher.Permission == GeoPositionPermission.Denied || watcher.Permission == GeoPositionPermission.Unknown)
            {
                latitudeTB.Text = "Latitude: " + DEFAULT_LATITUDE;
                longitudeTB.Text = "Longitude: " + DEFAULT_LONGITUDE;
            }
            else
            {
                latitudeTB.Text = "Latitude: " + watcher.Position.Location.Latitude.ToString();
                longitudeTB.Text = "Longitude: " + watcher.Position.Location.Longitude.ToString();
            }
        }

        
        private void geocodeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get search date string based on selection in control
            //String searchDate = "2013-04-10T00:00:00";
            String searchDate = getSearchDate(this.datePicker.SelectedIndex);

            // Get Distance index from Control
            String distanceIndex = distancePicker.SelectedIndex.ToString();

            // Get Address from text box
            String searchAddress = addressTextBox.Text;

            NavigationService.Navigate(new Uri("/GeocodePage.xaml?address=" + searchAddress + "&date=" + searchDate + "&dist=" + distanceIndex, UriKind.Relative));
        }

        private void addressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                geocodeButton.Focus();
                GeneralTransform transform = geocodeButton.TransformToVisual(scrollViewer2);
                Point buttonPos = transform.Transform(new Point(0, 0));
                scrollViewer2.ScrollToVerticalOffset(buttonPos.Y);
                /*
                // Get search date string based on selection in control
                //String searchDate = "2013-04-10T00:00:00";
                String searchDate = getSearchDate(this.datePicker.SelectedIndex);

                // Get Distance index from Control
                String distanceIndex = distancePicker.SelectedIndex.ToString();

                // Get Address from text box
                String searchAddress = addressTextBox.Text;

                NavigationService.Navigate(new Uri("/GeocodePage.xaml?address=" + searchAddress + "&date=" + searchDate + "&dist=" + distanceIndex, UriKind.Relative));
                */
            }
        }


    }
}