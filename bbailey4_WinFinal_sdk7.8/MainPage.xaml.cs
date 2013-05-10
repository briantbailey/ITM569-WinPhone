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
using System.Diagnostics;
using System.Device.Location;

namespace bbailey4_WinFinal_sdk7._8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Distance Array Values In Meters
        static readonly double[] DISTANCE_ARRAY_METERS = { 30.48, 76.2, 152.4, 304.8, 402.336, 804.672, 1609.344 };
        // Distance Array Values In Degrees Latitude
        static readonly double[] DISTANCE_ARRAY_DEGREES_LATITUDE = { 0.000274, 0.000686, 0.001372, 0.002745, 0.003623, 0.007246, 0.014493 };
        // Distance Array Values In Degrees Longitude
        static readonly double[] DISTANCE_ARRAY_DEGREES_LONGITUDE = { 0.000451, 0.001127, 0.002255, 0.004509, 0.005952, 0.011905, 0.023810 };


        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            //this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }


        // Handle selection changed on ListBox
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (MainListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + MainListBox.SelectedIndex, UriKind.Relative));

            // Reset selected index to -1 (no selection)
            MainListBox.SelectedIndex = -1;
        }


        // When page is navigated and not on a back navigation load data
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get parameters from navigation url
            String latitude = "";
            String longitude = "";
            String distancePos = "";
            String searchDate = "";
            NavigationContext.QueryString.TryGetValue("lat", out latitude);
            NavigationContext.QueryString.TryGetValue("long", out longitude);
            NavigationContext.QueryString.TryGetValue("dist", out distancePos);
            NavigationContext.QueryString.TryGetValue("date", out searchDate);

            // Build Query String
            //String queryString = "?$where=within_box(location,+42.00,+-88.55,+41.55,+-87.35)+AND+date_of_occurrence%3E='2013-02-10T00:00:00'&$order=date_of_occurrence+DESC";
            String queryString = "?$where=within_box(location,+"
               + (double.Parse(latitude) + DISTANCE_ARRAY_DEGREES_LATITUDE[int.Parse(distancePos)]).ToString() + ",+"
               + (double.Parse(longitude) - DISTANCE_ARRAY_DEGREES_LONGITUDE[int.Parse(distancePos)]).ToString() + ",+"
               + (double.Parse(latitude) - DISTANCE_ARRAY_DEGREES_LATITUDE[int.Parse(distancePos)]).ToString() + ",+"
               + (double.Parse(longitude) + DISTANCE_ARRAY_DEGREES_LONGITUDE[int.Parse(distancePos)]).ToString() + ")+AND+"
               + "date_of_occurrence%3E='" + searchDate + "'&$order=date_of_occurrence+DESC";

            GeoCoordinate myGeoCoordinate = null;
            // Create GeoCoordinate from user lat and long to pass to load data also
            if (e.NavigationMode == System.Windows.Navigation.NavigationMode.New)
            {
                myGeoCoordinate = new GeoCoordinate(double.Parse(latitude), double.Parse(longitude));
            }

            if (!App.ViewModel.IsDataLoaded && e.NavigationMode == System.Windows.Navigation.NavigationMode.New)
            {
                App.ViewModel.LoadData(queryString, DISTANCE_ARRAY_METERS[int.Parse(distancePos)], myGeoCoordinate);
            }
            else if (App.ViewModel.IsDataLoaded && e.NavigationMode == System.Windows.Navigation.NavigationMode.New)
            {
                App.ViewModel.ClearData();
                App.ViewModel.LoadData(queryString, DISTANCE_ARRAY_METERS[int.Parse(distancePos)], myGeoCoordinate);
            }

        }

        /*
        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
        //*/

    }
}