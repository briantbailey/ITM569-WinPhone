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

namespace bbailey4_WinFinal_sdk7._8.Models
{
    public class CrimeRecord
    {
        public String caseNum { get; set; }
        public String dateOf { get; set; }
        public String block { get; set; }
        public String iucr { get; set; }
        public String primaryDesc { get; set; }
        public String secondaryDesc { get; set; }
        public String locationDesc { get; set; }
        public String arrest { get; set; }
        public String domestic { get; set; }
        public String beat { get; set; }
        public String ward { get; set; }
        public String fbi_cd { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double distanceToMyLocation { get; set; }

        // Constructor
        public CrimeRecord()
        {
        }

    } // end CrimeRecord
}
