using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using bbailey4_WinFinal_sdk7._8.ViewModels;
using System.Net;
using System.Device.Location;


namespace bbailey4_WinFinal_sdk7._8
{
    public class MainViewModel : BaseViewModel
    {
        double distance;

        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.IsDataLoading = false;
            NotifyPropertyChanged("ProgressBarVisibility");
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        public GeoCoordinate MyGeoCoordinate { get; set; }

        public bool IsDataLoading
        {
            get;
            private set;
        }

        public Visibility ProgressBarVisibility
        {
            get
            {
                return this.IsDataLoading ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }


        public void ClearData()
        {
            this.Items.Clear();
        }


        public void LoadData(String query, double distanceRadius, GeoCoordinate geoCoordinate)
        {
            this.IsDataLoading = true;
            NotifyPropertyChanged("ProgressBarVisibility");

            this.distance = distanceRadius;

            if (geoCoordinate != null)
            {
                MyGeoCoordinate = geoCoordinate;
            }
            else
            {
                MyGeoCoordinate = new GeoCoordinate();
            }

            // Chicago Socrata Data Resource Endpoint
            String stringURL = "https://data.cityofchicago.org/resource/x2n5-8w5q.json";
            String queryParam = query;

            // Web Request for JSON
            WebClient client = new WebClient();
            Uri uri = new Uri(stringURL + queryParam, UriKind.Absolute);
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(uri);
        }


        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                // Parse JSON for crime record data
                Newtonsoft.Json.Linq.JArray crimeRecordsArray = Newtonsoft.Json.Linq.JArray.Parse(e.Result);
                foreach (Newtonsoft.Json.Linq.JObject item in crimeRecordsArray)
                {
                    ItemViewModel crimeRecord = new ItemViewModel();
                    crimeRecord.CaseNo = item["case_"].ToString();
                    crimeRecord.DateOf = item["date_of_occurrence"].ToString();
                    crimeRecord.Block = item["block"].ToString();
                    crimeRecord.iucr = item["_iucr"].ToString();
                    crimeRecord.PrimaryDesc = item["_primary_decsription"].ToString();
                    crimeRecord.SecondaryDesc = item["_secondary_description"].ToString();
                    crimeRecord.LocationDesc = item["_location_description"].ToString();
                    crimeRecord.Arrest = (item["arrest"].ToString() == "N") ? "No" : "Yes";
                    crimeRecord.Domestic = (item["domestic"].ToString() == "N") ? "No" : "Yes";
                    crimeRecord.Beat = item["beat"].ToString();
                    crimeRecord.Ward = item["ward"].ToString();
                    crimeRecord.Fbi_Cd = item["fbi_cd"].ToString();                 
                    crimeRecord.Latitude = double.Parse(item["latitude"].ToString());
                    crimeRecord.Longitude = double.Parse(item["longitude"].ToString());
                    GeoCoordinate recordGeoCoordinate = new GeoCoordinate(crimeRecord.Latitude, crimeRecord.Longitude);
                    crimeRecord.DistanceToMyLocation = recordGeoCoordinate.GetDistanceTo(MyGeoCoordinate);

                    if (crimeRecord.DistanceToMyLocation <= this.distance)
                    {
                        this.Items.Add(crimeRecord);
                    }
                }
                this.IsDataLoading = false;
                NotifyPropertyChanged("ProgressBarVisibility");
                this.IsDataLoaded = true;
            }
        }


    } //end MainViewModel
}