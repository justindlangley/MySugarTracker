using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySugarTracker.Models
{
    public class PatientSugarData
    {
        public int PatientSugarDataID { get; set; }
        public string UserID { get; set;}        
        public int patientSugarReading { get; set; }
        public DateTime dateTime { get; set; }
        
    }
}