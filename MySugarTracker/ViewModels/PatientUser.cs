using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySugarTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using MySugarTracker.ViewModels;

namespace MySugarTracker.ViewModels
{
    public class PatientUser : Controller

    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public bool? CardioVascularDisease { get; set; }

        public bool? HighBloodPressure { get; set; }

        public bool? Female { get; set; }

        public int HeightInInches { get; set; }

        public int WeightInPounds { get; set; }

        public bool? Pregnant { get; set; }

        public bool SMSPref { get; set; }

        public bool EmailPref { get; set; }

        public int HighAlert { get; set; }

        public int LowAlert { get; set; }

        public DateTime TestTime1 { get; set; }

        public DateTime TestTime2 { get; set; }

        public DateTime TestTime3 { get; set; }

        public DateTime TestTime4 { get; set; }

        public bool? ThyroidDisease { get; set; }
    }
}