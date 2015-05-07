using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MySugarTracker.Models
{
    public class Patient 
    {

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name="History of Cardiovascular disease?")]
        public bool? CardioVascularDisease { get; set; }
        [Required]
        [Display(Name = "History of High Blood Pressure?")]
        public bool? HighBloodPressure { get; set; }
        [Required]
        [Display(Name = "History of Thyroid disease?")]
        public bool? ThyroidDisease { get; set; }
        [Required]
        [Display(Name = "Female?")]
        public bool? Female { get; set; }
        [Required]
        [Display(Name = "Pregnant?")]
        public bool? Pregnant { get; set; }

        //Does patient prefer to receive notifications and reminders from email or SMS, or both.
        [Required]
        [Display(Name = "Prefer Email Notification?")]
        public bool EmailPref { get; set; }
        [Required]
        [Display(Name = "Prefer Text Message Notification?")]
        public bool SMSpref { get; set; }
        [Display(Name = "Low Blood Sugar Alert Level")]
        public int LowAlert { get; set; }
        [Display(Name = "High Blood Sugar Alert Level")]
        public int HighAlert { get; set; }

        [Display(Name = "")]
        public DateTime TestTime1 { get; set; }
        public DateTime TestTime2 { get; set; }
        public DateTime TestTime3 { get; set; }
        public DateTime TestTime4 { get; set; }

        
        DateTime today = DateTime.Today;
        public TimeSpan Age 
        { 
            get 
                            { 
                            return (today - BirthDate); 
                            }
        }

        //Use Height and weight to calculate BMI
        [Required]
        [Display(Name = "Weight in Pounds")]
        public int WeightInPounds { get; set; }
        [Required]
        [Display(Name = "Height in Inches")]
        public int HeightInInches { get; set; }
        [Display(Name = "Body Mass Index (BMI)")]
        public int BMI
        {
            get
            {
                return (WeightInPounds * 703) / (HeightInInches * HeightInInches);
            }
        }
        [Key]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<PatientSugarData> PatientSugarData { get; set; }
    }
}