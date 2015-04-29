using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MySugarTracker.Models
{
    public class Patient : User
    {
        [Required]
        [Key]
        [ForeignKey("User")]
        public int PatientID { get; set; }


        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public int BirthDate { get; set; }

        [Required]
        public bool? CVD { get; set; }
        [Required]
        public bool? HBP { get; set; }
        [Required]
        public bool? Thyroid { get; set; }
        [Required]
        public bool? Female { get; set; }
        [Required]
        public bool? Pregnant { get; set; }

        //Does patient prefer to receive notifications and reminders from email or SMS, or both.
        [Required]
        public bool EmailPref { get; set; }
        [Required]
        public bool SMSpref { get; set; }

        //public int Age { get { return DateTime.Now.Year - BirthDate; } set; }

        //Use Height and weight to calculate BMI
        [Required]
        public int WeightInPounds { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int HeightInInches { get; set; }
        public int BMI
        {
            get
            {
                return (WeightInPounds * 703) / (HeightInInches * HeightInInches);
            }
        }
    }
}