using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MySugarTracker.Models
{
    public class Patient : User
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public int BirthDate { get; set; }
        

        public bool? CVD { get; set; }
        public bool? HBP { get; set; }
        public bool? Thyroid { get; set;}
        public bool? Female { get; set;}
        public bool? Pregnant { get; set; }
       
        //Does patient prefer to receive notifications and reminders from email or SMS, or both.
        public bool EmailPref {get; set;}
        public bool SMSpref { get; set; }

        //public int Age {get; {return (DateTime.Now - BirthDate)}} 

        //Use Height and weight to calculate BMI
        public int Weight { get; set;}
        public int Height { get; set; }
        public int BMI {get; set; }


    }
}