using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using MySugarTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using MySugarTracker.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySugarTracker.ViewModels
{
    public class PatientUser 

    {
        

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Cardiovascular Disease?")]
        public bool? CardioVascularDisease { get; set; }

        [Display(Name = "High Blood Pressure?")]
        public bool? HighBloodPressure { get; set; }

        [Display(Name = "Female?")]
        public bool? Female { get; set; }

        [Display(Name = "Height (inches)")]
        public int HeightInInches { get; set; }

        [Display(Name = "Weight (pounds)")]
        public int WeightInPounds { get; set; }

        [Display(Name = "Pregnant?")]
        public bool? Pregnant { get; set; }

        [Display(Name = "Prefer SMS Notification?")]
        public bool SMSPref { get; set; }

        [Display(Name = "Prefer Email Notification?")]
        public bool EmailPref { get; set; }

        [Display(Name = "High Sugar Level Value")]
        public int HighAlert { get; set; }

        [Display(Name = "Low Sugar Level Value")]
        public int LowAlert { get; set; }
        
        [Display(Name = "Daily First Sugar Reading")]
        public DateTime TestTime1 { get; set; }

        [Display(Name = "Daily Second Sugar Reading")]
        public DateTime TestTime2 { get; set; }

        [Display(Name = "Daily Third Sugar Reading")]
        public DateTime TestTime3 { get; set; }

        [Display(Name = "Daily Fourth Sugar Reading")]
        public DateTime TestTime4 { get; set; }

        [Display(Name = "Thyroid Disease?")]
        public bool? ThyroidDisease { get; set; }

        public string UserID { get; set; }

        public Highcharts MyChart { get; set; }

    }
}