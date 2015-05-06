using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MySugarTracker.Models
{
    public class User
    {
        [Required]
        public int UserID { get; set; }


        //Valid values are D=Dr P=Patient C=CaseManager
        [Required]
        public char Role { get; set; }

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage="You must enter a valid email.")]
        [EmailAddress]
        public string Email { get; set; }

        
        public long PhoneNumber { get; set; }

        [Display(Name="Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        
    }
}