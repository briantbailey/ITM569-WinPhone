using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using bbailey4_WinFinal_sdk7._8.ViewModels;
using bbailey4_WinFinal_sdk7._8.Models;

namespace bbailey4_WinFinal_sdk7._8
{
    public class ItemViewModel : BaseViewModel
    {
        protected CrimeRecord crimeRecord;

        public ItemViewModel()
        {
            this.crimeRecord = new CrimeRecord();
        }


        public string PrimaryDesc
        {
            get
            {
                return crimeRecord.primaryDesc;
            }
            set
            {
                if (value != crimeRecord.primaryDesc)
                {
                    crimeRecord.primaryDesc = value;
                    NotifyPropertyChanged("PrimaryDesc");
                }
            }
        }


        public string Block
        {
            get
            {
                return crimeRecord.block;
            }
            set
            {
                if (value != crimeRecord.block)
                {
                    crimeRecord.block = value;
                    NotifyPropertyChanged("Block");
                }
            }
        }


        public double Latitude
        {
            get
            {
                return crimeRecord.latitude;
            }
            set
            {
                if (value != crimeRecord.latitude)
                {
                    crimeRecord.latitude = value;
                    NotifyPropertyChanged("Latitude");
                }
            }
        }


        public double Longitude
        {
            get
            {
                return crimeRecord.longitude;
            }
            set
            {
                if (value != crimeRecord.longitude)
                {
                    crimeRecord.longitude = value;
                    NotifyPropertyChanged("Longitude");
                }
            }
        }


        public double DistanceToMyLocation
        {
            get
            {
                return crimeRecord.distanceToMyLocation;
            }
            set
            {
                if (value != crimeRecord.distanceToMyLocation)
                {
                    crimeRecord.distanceToMyLocation = value;
                    NotifyPropertyChanged("DistanceToMyLocation");
                }
            }
        }


        public string CaseNo
        {
            get
            {
                return crimeRecord.caseNum;
            }
            set
            {
                if (value != crimeRecord.caseNum)
                {
                    crimeRecord.caseNum = value;
                    NotifyPropertyChanged("CaseNo");
                }
            }
        }


        public string DateOf
        {
            get
            {
                return crimeRecord.dateOf;
            }
            set
            {
                if (value != crimeRecord.dateOf)
                {
                    crimeRecord.dateOf = value;
                    NotifyPropertyChanged("DateOf");
                }
            }
        }


        public string iucr
        {
            get
            {
                return crimeRecord.iucr;
            }
            set
            {
                if (value != crimeRecord.iucr)
                {
                    crimeRecord.iucr = value;
                    NotifyPropertyChanged("iucr");
                }
            }
        }


        public string SecondaryDesc
        {
            get
            {
                return crimeRecord.secondaryDesc;
            }
            set
            {
                if (value != crimeRecord.secondaryDesc)
                {
                    crimeRecord.secondaryDesc = value;
                    NotifyPropertyChanged("SecondaryDesc");
                }
            }
        }


        public string LocationDesc
        {
            get
            {
                return crimeRecord.locationDesc;
            }
            set
            {
                if (value != crimeRecord.locationDesc)
                {
                    crimeRecord.locationDesc = value;
                    NotifyPropertyChanged("LocationDesc");
                }
            }
        }


        public string Arrest
        {
            get
            {
                return crimeRecord.arrest;
            }
            set
            {
                if (value != crimeRecord.arrest)
                {
                    crimeRecord.arrest = value;
                    NotifyPropertyChanged("Arrest");
                }
            }
        }


        public string Domestic
        {
            get
            {
                return crimeRecord.domestic;
            }
            set
            {
                if (value != crimeRecord.domestic)
                {
                    crimeRecord.domestic = value;
                    NotifyPropertyChanged("Domestic");
                }
            }
        }


        public string Beat
        {
            get
            {
                return crimeRecord.beat;
            }
            set
            {
                if (value != crimeRecord.beat)
                {
                    crimeRecord.beat = value;
                    NotifyPropertyChanged("Beat");
                }
            }
        }


        public string Ward
        {
            get
            {
                return crimeRecord.ward;
            }
            set
            {
                if (value != crimeRecord.ward)
                {
                    crimeRecord.ward = value;
                    NotifyPropertyChanged("Ward");
                }
            }
        }


        public string Fbi_Cd
        {
            get
            {
                return crimeRecord.fbi_cd;
            }
            set
            {
                if (value != crimeRecord.fbi_cd)
                {
                    crimeRecord.fbi_cd = value;
                    NotifyPropertyChanged("Fbi_Cd");
                }
            }
        }

    } //end ItemViewModel
}