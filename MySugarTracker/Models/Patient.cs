﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MySugarTracker.Models
{
    public class Patient 
    {
        [Required]
        [Key]
        [ForeignKey("User")]
        public int UserID { get; set; }

        //[Required]
        //public int DrID { get; set; }

    
        //[ForeignKey("User")]
        //public int CaseManagerID {get; set;}


        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool? CardioVascularDisease { get; set; }
        [Required]
        public bool? HighBloodPressure { get; set; }
        [Required]
        public bool? ThyroidDisease { get; set; }
        [Required]
        public bool? Female { get; set; }
        [Required]
        public bool? Pregnant { get; set; }

        //Does patient prefer to receive notifications and reminders from email or SMS, or both.
        [Required]
        public bool EmailPref { get; set; }
        [Required]
        public bool SMSpref { get; set; }

        public int LowAlert { get; set; }
        public int HighAlert { get; set; }

        public DateTime TestTime1 { get; set; }
        public DateTime TestTime2 { get; set; }
        public DateTime TestTime3 { get; set; }
        public DateTime TestTime4 { get; set; }

        

        //public int Age { get { return DateTime.Now.Year - BirthDate; } set; }

        //Use Height and weight to calculate BMI
        [Required]
        public int WeightInPounds { get; set; }
        [Required]
        public int HeightInInches { get; set; }
        public int BMI
        {
            get
            {
                return (WeightInPounds * 703) / (HeightInInches * HeightInInches);
            }
        }
        public virtual User User { get; set; }
        public virtual ICollection<PatientSugarData> PatientSugarData { get; set; }
    }
}