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
        [Key]
        public int PatientSugarDataID { get; set; }
        public string UserID { get; set;}  
        [Display(Name="Patient Glucose Reading")]
        public int patientSugarReading { get; set; }
        [Display(Name="Date and Time")]
        public DateTime dateTime { get; set; }
        
    }
}