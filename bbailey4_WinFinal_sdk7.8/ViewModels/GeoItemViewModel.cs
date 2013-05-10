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

namespace bbailey4_WinFinal_sdk7._8.ViewModels
{
    public class GeoItemViewModel : BaseViewModel
    {
        public GeoItemViewModel()
        { 
        }

        private String _addressLine;
        public String AddressLine
        {
            get
            {
                return _addressLine;
            }
            set
            {
                if (value != _addressLine)
                {
                    _addressLine = value;
                    NotifyPropertyChanged("AddressLine");
                }
            }
        }

        private String _latitude;
        public String Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                if (value != _latitude)
                {
                    _latitude = value;
                    NotifyPropertyChanged("Latitude");
                }
            }
        }

        private String _longitude;
        public String Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (value != _longitude)
                {
                    _longitude = value;
                    NotifyPropertyChanged("Longitude");
                }
            }
        }


    }
}
