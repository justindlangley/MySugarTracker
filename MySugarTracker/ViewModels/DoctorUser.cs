﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySugarTracker.ViewModels
{
    public class DoctorUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<PatientUser> PatientList = new List<PatientUser>();
    }
}