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
using System.Diagnostics;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using bbailey4_WinFinal_sdk7._8.GeocodeService;
using bbailey4_WinFinal_sdk7._8.ViewModels;

namespace bbailey4_WinFinal_sdk7._8
{
    public partial class GeocodePage : PhoneApplicationPage
    {

        private String searchDate;
        private String distanceIndex;

        public GeocodePage()
        {
            InitializeComponent();
            DataContext = App.GeoViewModel;
            emptyAddressTB.Visibility = Visibility.Collapsed;
        }

        // Handle selection changed on ListBox
        private void GeoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (GeoListBox.SelectedIndex == -1)
                return;

            String latitude = App.GeoViewModel.Items[GeoListBox.SelectedIndex].Latitude.ToString();
            //Debug.WriteLine(latitude);
            String longitude = App.GeoViewModel.Items[GeoListBox.SelectedIndex].Longitude.ToString();
            //Debug.WriteLine(longitude);

            // Navigate to Crime List
            NavigationService.Navigate(new Uri("/MainPage.xaml?lat=" + latitude + "&long=" + longitude + "&date=" + searchDate + "&dist=" + distanceIndex, UriKind.Relative));

            // Reset selected index to -1 (no selection)
            GeoListBox.SelectedIndex = -1;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get parameters from navigation url
            distanceIndex = "";
            searchDate = "";
            String streetAddress = "";
            NavigationContext.QueryString.TryGetValue("dist", out distanceIndex);
            NavigationContext.QueryString.TryGetValue("date", out searchDate);
            NavigationContext.QueryString.TryGetValue("address", out streetAddress);

            if (!App.GeoViewModel.IsDataLoaded && e.NavigationMode == System.Windows.Navigation.NavigationMode.New && streetAddress != "")
            {
                App.GeoViewModel.LoadData(streetAddress + ", Chicago, IL");
            }
            else if (App.GeoViewModel.IsDataLoaded && e.NavigationMode == System.Windows.Navigation.NavigationMode.New && streetAddress != "")
            {
                App.GeoViewModel.ClearData();
                App.GeoViewModel.LoadData(streetAddress + ", Chicago, IL");
            }
            else if (e.NavigationMode == System.Windows.Navigation.NavigationMode.New && streetAddress == "")
            {
                App.GeoViewModel.ClearData();
                emptyAddressTB.Visibility = Visibility.Visible;
            }
        }

    } //end GeocodePage
}