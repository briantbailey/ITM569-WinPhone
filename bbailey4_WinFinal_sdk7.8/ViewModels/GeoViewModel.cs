using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Diagnostics;
using bbailey4_WinFinal_sdk7._8.GeocodeService;

namespace bbailey4_WinFinal_sdk7._8.ViewModels
{
    public class GeoViewModel : BaseViewModel
    {
        private GeocodeService.GeocodeServiceClient geocodeClient;

        public GeoViewModel()
        {
            this.Items = new ObservableCollection<GeoItemViewModel>();
            this.IsAddressResult = true;
            NotifyPropertyChanged("AddressResultVisibility");
            geocodeClient = new GeocodeService.GeocodeServiceClient("BasicHttpBinding_IGeocodeService");
            geocodeClient.GeocodeCompleted += new EventHandler<GeocodeService.GeocodeCompletedEventArgs>(geocodeClient_GeocodeCompleted);
        }

        public ObservableCollection<GeoItemViewModel> Items { get; private set; }

        public bool IsAddressResult
        {
            get;
            set;
        }

        public void ClearData()
        {
            this.Items.Clear();
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public Visibility AddressResultVisibility
        {
            get
            {
                return this.IsAddressResult ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public void LoadData(String query)
        {
                GeocodeService.GeocodeRequest geoRequest = new GeocodeService.GeocodeRequest();
                geoRequest.Credentials = new GeocodeService.Credentials();
                geoRequest.Credentials.ApplicationId = MapKey.BingApiKey;
                geoRequest.Options = new GeocodeService.GeocodeOptions()
                {
                    Filters = new ObservableCollection<FilterBase>
                {
                    new ConfidenceFilter()
                    {
                        MinimumConfidence = Confidence.Medium
                    }
                }
                };
                geoRequest.Query = query;
                geocodeClient.GeocodeAsync(geoRequest);
        } //end method

        void geocodeClient_GeocodeCompleted(object sender, GeocodeService.GeocodeCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result.Results.Count > 0)
                {
                    foreach (var item in e.Result.Results)
                    {
                        //Debug.WriteLine(item.Locations[0].Latitude.ToString());
                        //Debug.WriteLine(item.Locations[0].Longitude.ToString());
                        //Debug.WriteLine(item.Address.FormattedAddress.ToString());
                        GeoItemViewModel geoItem = new GeoItemViewModel();
                        geoItem.Latitude = item.Locations[0].Latitude.ToString();
                        geoItem.Longitude = item.Locations[0].Longitude.ToString();
                        geoItem.AddressLine = item.Address.FormattedAddress.ToString();
                        this.Items.Add(geoItem);
                        this.IsAddressResult = true;
                        NotifyPropertyChanged("AddressResultVisibility");
                    }
                    this.IsDataLoaded = true;
                }
                else
                {
                    //Debug.WriteLine("no results");
                    this.IsAddressResult = false;
                    NotifyPropertyChanged("AddressResultVisibility");
                    this.IsDataLoaded = false;
                }
            }
            else
            {
                //Debug.WriteLine("Geocode Error");
                MessageBox.Show("Error in Geocoding Service! Please go back and try again.");
            }
        } //end method
    
    } // end GeoViewModel
}
