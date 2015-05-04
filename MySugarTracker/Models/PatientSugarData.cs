using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySugarTracker.Models
{
    public class PatientSugarData
    {
        public int PatientSugarDataID { get; set; }
        [ForeignKey ]
        public int PatientID { get; set;}        
        public int patientSugarReading { get; set; }
        public DateTime dateTime { get; set; }
        
    }
}